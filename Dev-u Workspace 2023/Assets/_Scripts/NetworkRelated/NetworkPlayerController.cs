using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerController : NetworkBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 50f;

    [SerializeField]
    private GameObject bulletPrefab;

    private InputManager inputManager;

    private NetworkVariable<int> variavel1 = new NetworkVariable<int>(5, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        if (!IsOwner)
            return;

        Move(inputManager.OnMove());

        if (inputManager.OnShoot())
        {
            ShootServerRpc();
            UpdateValue();
        }
    }

    private void UpdateValue()
    {
        variavel1.Value++;
        print(OwnerClientId+ " " + variavel1.Value);
    }

    private void Move(Vector2 movementDirection)
    {
        rb.velocity = new Vector3(movementDirection.x, -1f, movementDirection.y) * speed;
    }
    [ServerRpc]
    private void ShootServerRpc()
    {
        GameObject clone = Instantiate(bulletPrefab, transform.position + Vector3.forward, Quaternion.identity);
        clone.GetComponent<NetworkObject>().Spawn(true);
    }
}

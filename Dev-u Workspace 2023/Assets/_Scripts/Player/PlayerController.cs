using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementDirection = Vector2.zero;

    private Rigidbody rb;

    [SerializeField]
    private float speed = 50f;

    [SerializeField]
    private GameObject bulletPrefab;

    private InputManager inputManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = InputManager.Instance;
    }

    void Update()
    {

        Move(inputManager.OnMove());

        if (inputManager.OnShoot())
            Shoot();

    }

    private void Move(Vector2 movementDirection)
    {
        rb.velocity = new Vector3(movementDirection.x, -1f, movementDirection.y) * speed; 
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position + Vector3.forward, Quaternion.identity);
    }
}

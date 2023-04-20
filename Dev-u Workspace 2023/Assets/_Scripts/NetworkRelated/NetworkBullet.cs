using System;
using System.Collections;
using System.Collections.Generic;
using CapuchoUtils;
using Unity.Netcode;
using UnityEngine;

public class NetworkBullet : NetworkBehaviour
{
    private Timer timer;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * 10f;

        timer = new Timer(5f);
        timer.OnTimerEnd += DestroyBullet;

    }

    private void DestroyBullet()
    {
        GetComponent<NetworkObject>().Despawn();
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
    }
}


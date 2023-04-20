using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Relay;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button _serverBtn;
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _clientButton;
    void Start()
    {
        _serverBtn.onClick.AddListener(() => StartServer());
        _hostButton.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        _clientButton.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }

    private void StartServer()
    {
        NetworkManager.Singleton.StartServer();
    }

}

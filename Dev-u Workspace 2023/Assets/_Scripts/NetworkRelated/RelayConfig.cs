using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay.Models;
using UnityEngine.UI;

public class RelayConfig : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _codeText;
    [SerializeField]
    private TMP_InputField _inputField;
    private async void Start()
    {
         await UnityServices.InitializeAsync();
         await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void CreateRelay()
    {
        try
        {
           var allocation = await RelayService.Instance.CreateAllocationAsync(3);
           string code = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
           _codeText.text = code;

           RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
           NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();
        }
        catch (RelayServiceException error)
        {
            print(error);
        }
    }

    public async void JoinRelay()
    {
        try
        {
           var code = _inputField.text;
           var joinAllocation = await RelayService.Instance.JoinAllocationAsync(code);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
            NetworkManager.Singleton.StartClient();
        }
        catch (RelayServiceException error)
        {
            print(error);
        }
    }

}

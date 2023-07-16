using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] Button _serverBtn;
    [SerializeField] Button _hostBtn;
    [SerializeField] Button _clientBtn;

    private void Awake()
    {
        _serverBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        _hostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        _clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }


}

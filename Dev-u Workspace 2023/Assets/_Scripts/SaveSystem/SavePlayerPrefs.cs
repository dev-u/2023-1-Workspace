using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPrefs : MonoBehaviour
{
    private Transform _playerTransform;
    private void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
            SaveData();
        if(Input.GetKeyDown(KeyCode.L))
            LoadData();
    }
    public void SaveData()
    {
        PlayerData data = new PlayerData(_playerTransform.position);

        PlayerPrefs.SetFloat("playerX", data.PlayerPosition.x);
        PlayerPrefs.SetFloat("playerY", data.PlayerPosition.y);
        PlayerPrefs.SetFloat("playerZ", data.PlayerPosition.z);

    }
    public void LoadData() 
    {
        var xx = PlayerPrefs.GetFloat("playerX");
        var yy = PlayerPrefs.GetFloat("playerY");
        var zz = PlayerPrefs.GetFloat("playerZ");

        _playerTransform.position = new Vector3(xx, yy, zz); 
    }
}

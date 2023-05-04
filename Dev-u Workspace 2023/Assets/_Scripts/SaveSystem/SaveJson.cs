using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveJson : MonoBehaviour
{
    private Transform _playerTransform;
    private void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            SaveData();
        if (Input.GetKeyDown(KeyCode.L))
            LoadData();
    }
    public void SaveData()
    {
        PlayerData playerData = new PlayerData(_playerTransform.position);

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
   
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.json";

        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
        

        _playerTransform.position = playerData.PlayerPosition;

    }
}

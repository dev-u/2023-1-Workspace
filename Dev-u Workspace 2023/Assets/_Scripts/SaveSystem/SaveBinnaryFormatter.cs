using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveBinnaryFormatter : MonoBehaviour
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
        string path = Application.persistentDataPath + "/playerData.sav";
        PlayerData playerData = new PlayerData(_playerTransform.position);

        FileStream file = File.Create(path);
        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(file, playerData);
        file.Close();
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.sav";

        FileStream file = File.Open(path, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();

        PlayerData playerData = (PlayerData)formatter.Deserialize(file);
        file.Close();

        _playerTransform.position = playerData.PlayerPosition;

    }
}

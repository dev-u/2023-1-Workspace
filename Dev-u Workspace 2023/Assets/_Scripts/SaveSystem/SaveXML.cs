using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveXML : MonoBehaviour
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

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerData));
        FileStream fileStream = File.Create(Application.persistentDataPath + "/playerData.xml");
        xmlSerializer.Serialize(fileStream, playerData);
        fileStream.Close();
    }
    public void LoadData()
    {

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerData));
        FileStream fileStream = File.Open(Application.persistentDataPath + "/playerData.xml", FileMode.Open);
        PlayerData playerData = (PlayerData)xmlSerializer.Deserialize(fileStream);
        fileStream.Close();

        _playerTransform.position = playerData.PlayerPosition;

    }
}

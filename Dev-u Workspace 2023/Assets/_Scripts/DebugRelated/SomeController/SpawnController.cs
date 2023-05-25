using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace DevU
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private GameObject spawnPrefab;
        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

        private Pi obj;
        void Start()
        {
            obj = new Pi();
            
            foreach (var spawn in spawnPoints)
            {
                Instantiate(spawnPrefab, spawn.position, spawn.rotation);
                SomeLogicHere();
            }

            SomeLogicHere();

            var clone = Instantiate(spawnPrefab, spawnPoints[0].position * obj.pi, spawnPoints[0].rotation);
            clone.name = "Pi Obj";
                
        }

        private void SomeLogicHere()
        {
            for (int i = 0; i < 1000; i++)
                print(obj.pi);
        }
    }
}

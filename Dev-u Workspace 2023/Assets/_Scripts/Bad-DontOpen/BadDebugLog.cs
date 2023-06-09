using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevU
{
    public class BadDebugLog : MonoBehaviour
    {
        
        void Update()
        {
            for (int i = 0; i < 60; i++)
            {
                Debug.Log(i);
            }
        }
    }
}

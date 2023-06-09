using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevU
{
    
    public class BadCode : MonoBehaviour
    {
        float red = 0f;
        float blue = 0f;
        float green = 0f;

        private MeshRenderer _renderer;

        private void Start()
        {
           _renderer = GetComponent<MeshRenderer>();
        }
        void Update()
        {
            for (int i = 0; i < 10; i++)
            {

                _renderer.material.color = SlowCode();
            }
        }

        private Color SlowCode()
        {
            red += Time.deltaTime;
            if (red > 1f)red = 0f;

            blue += Time.deltaTime * 1.2f;
            if(blue > 1f) blue = 0f;

            green += Time.deltaTime * 1.3f;
            if(green > 1f) green = 0f;

            return new Color(red, green, blue);
        }
    }
}

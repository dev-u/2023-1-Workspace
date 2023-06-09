using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevU
{
    public class ChangeQualitySettings : MonoBehaviour
    {
        public void SetQuality(int index)
        {
            QualitySettings.SetQualityLevel(index);
        }

    }
}

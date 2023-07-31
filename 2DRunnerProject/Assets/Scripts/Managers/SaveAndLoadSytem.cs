using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class SaveAndLoadSytem
    {
        public static void Save(string name, float num) => PlayerPrefs.SetFloat(name, num);
        public static float Load(string name)
        {
            return PlayerPrefs.GetFloat(name);
        }
    }
}

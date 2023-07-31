using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class ObstacelsManager : MonoBehaviour
    {
        [Header("Obstacels")]
        [SerializeField] private GameObject[] onePlace_Obstacels;
        [SerializeField] private GameObject[] twoPlace_Obstacels;
        public void ActiveObstacel()
        {
            Disable_All_Obstacels();
            int onePlaceObstacel_Num = Random.Range(0, onePlace_Obstacels.Length);
            int twoPlaceObstacel_Num = Random.Range(0, twoPlace_Obstacels.Length);
            onePlace_Obstacels[onePlaceObstacel_Num].SetActive(true);
            twoPlace_Obstacels[twoPlaceObstacel_Num].SetActive(true);
        }
        private void Disable_All_Obstacels()
        {
            foreach (var item in onePlace_Obstacels)
            {
                item.SetActive(false);
            }
            foreach (var item in twoPlace_Obstacels)
            {
                item.SetActive(false);
            }
        }
    }
}

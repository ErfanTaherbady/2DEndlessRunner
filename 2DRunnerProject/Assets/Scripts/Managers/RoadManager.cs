using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class RoadManager : MonoBehaviour
    {
        #region Singelton
        public static RoadManager instance;
        private void Awake()
        {
            if (instance != null)
                return;
            instance = this;
        }
        #endregion
        [Header("Road Polling Refrense")]
        [SerializeField] private Transform currentSection;
        [SerializeField] private Transform nextSection;
        [SerializeField] private float distanceBettwenRoad;

        
        public void PollingToNextRoad()
        {
            nextSection.position = new Vector2(currentSection.position.x + distanceBettwenRoad, nextSection.position.y);
            nextSection.GetComponent<ObstacelsManager>().ActiveObstacel();
            Transform nextRoadSection = nextSection.transform;
            nextSection = currentSection;
            currentSection = nextRoadSection;
        }
    }
}

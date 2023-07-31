using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class HealthManager : MonoBehaviour
    {
        #region Singelton
        public static HealthManager instance;
        private void Awake()
        {
            if (instance != null)
                return;
            instance = this;
        }
        #endregion
        [Header("UI Refrenses")]
        [SerializeField] private GameObject[] hearts;
        [SerializeField] private GameObject[] empty_Hearts;

        private int currentHealth = 3;
        public void GetHurt()
        {
            hearts[currentHealth - 1].SetActive(false);
            empty_Hearts[currentHealth - 1].SetActive(true);
            currentHealth--;
            if (currentHealth == 0)
                PlayerController.instance.Die();
        }
    }
}

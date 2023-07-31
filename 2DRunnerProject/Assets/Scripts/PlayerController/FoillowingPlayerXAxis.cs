using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class FoillowingPlayerXAxis : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private void Update()
        {
            transform.position = new Vector2(target.position.x, transform.position.y);
        }
    }
}

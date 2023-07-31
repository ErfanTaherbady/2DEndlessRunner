using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class AnimationController : MonoBehaviour
    {
        #region Singelton
        public static AnimationController instance;
        private void Awake()
        {
            if (instance != null)
                return;
            instance = this;
        }
        #endregion
        private Animator anims;
        private void Start()
        {
            anims = GetComponentInChildren<Animator>();   
        }
        public void Runing(bool isRuning) => anims.SetBool(Tags.Run_ANIMATION, isRuning);
        public void Jumping() => anims.SetTrigger(Tags.JUMP_ANIMATION);
        public void GetHurt() => anims.SetTrigger(Tags.HURT_ANIMATION);
        public void Die() => anims.SetBool(Tags.DIE_ANIMATION, true);
    }
}

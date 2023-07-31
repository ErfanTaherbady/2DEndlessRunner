using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErfanDeveloper
{
    public class PlayerController : MonoBehaviour
    {
        #region Singelton
        public static PlayerController instance;
        private void Awake()
        {
            if (instance != null)
                return;
            instance = this;
        }
        #endregion
        [Header("Moving Refrense")]
        [SerializeField] private float moveingSpeed = 7f;
        [SerializeField] private float jumpForce;

        private Rigidbody2D rb;
        public bool isGrounded;
        private bool getting_Hurt = false;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (!GameManager.instace.canPlayGame || getting_Hurt)
                return;
            transform.Translate(Vector2.right * moveingSpeed * Time.deltaTime);
            AnimationController.instance.Runing(true);


            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
        private void Jump()
        {
            if (!isGrounded)
                return;
            AudioManager.instance.Jump();
            AnimationController.instance.Jumping();
            rb.AddForce(Vector2.up * jumpForce);
        }

        #region PhisycsFounctions
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                isGrounded = true;
        }
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                isGrounded = false;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Road_Section"))
            {
                RoadManager.instance.PollingToNextRoad();
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Obstacel"))
            {
                other.gameObject.SetActive(false);
                StartCoroutine(GetHurt());
            }
        }
        #endregion

        private IEnumerator GetHurt()
        {
            AudioManager.instance.GetHurt();
            AnimationController.instance.GetHurt();
            HealthManager.instance.GetHurt();
            getting_Hurt = true;
            yield return new WaitForSeconds(0.7f);
            getting_Hurt = false;
        }
        public void Die()
        {
            AnimationController.instance.Die();
            GameManager.instace.isGameOver = true;
            OnGUIManager.instance.UpdateUiState(GameState.EndGame);
            GameManager.instace.Die();
            AudioManager.instance.LoseGame();
        }
    }
}

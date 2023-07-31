using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singelton
    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion
    [Header("Sounds Refrens")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startGameSound;
    [SerializeField] private AudioClip loseGameSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip jumpSound;
    public void StartGame() => audioSource.PlayOneShot(startGameSound);
    public void LoseGame() => audioSource.PlayOneShot(loseGameSound);
    public void GetHurt() => audioSource.PlayOneShot(hurtSound);
    public void Jump() => audioSource.PlayOneShot(jumpSound);
}

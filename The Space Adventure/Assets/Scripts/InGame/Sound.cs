using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rhcodepi
{
    public class Sound : MonoBehaviour
    {
        [SerializeField] AudioClip jump, coin, gameOver;
        [SerializeField] AudioSource audioSource;
        
        public void SetJumpSound()
        {
            audioSource.clip = jump;
            audioSource.Play();
        }

        public void SetCoinSound()
        {
            audioSource.clip = coin;
            audioSource.Play();
        }
        
        public void SetGameOverSound()
        {
            audioSource.clip = gameOver;
            audioSource.Play();
        }
    }
}



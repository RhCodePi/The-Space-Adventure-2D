using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rhcodepi
{
    public class Music : MonoBehaviour
    {
        public static Music instance;
        [SerializeField] AudioSource music;
        void Awake()
        {
            Singleton();
        }

        void Singleton()
        {
            if(instance != null)
                Destroy(gameObject);
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
        }

        public void SetMusic(bool isPlay)
        {
            if(isPlay)
            {
                if(!music.isPlaying)
                {
                    music.Play();
                }
            }
            else{
                if(music.isPlaying)
                {
                    music.Stop();
                }
            }
        }
    }
}


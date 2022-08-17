using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace rhcodepi
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] Sprite[] volumeSprites;
        [SerializeField] Button volume;
        private void Start()
        {
            if (!SaveData.isDataOnPrefs())
                SaveData.SetSaveEasy(1);
            if (!SaveData.isMusicOnPrefs())
                SaveData.SetSaveMusic(1);
            MusicSetup();
        }

        public void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }
        public void HighScore()
        {
            SceneManager.LoadScene("HighScore");
        }
        public void Settings()
        {
            SceneManager.LoadScene("Settings");
        }

        public void MusicBtnSetup()
        {
            if (SaveData.GetMusic() == 1)
            {
                SaveData.SetSaveMusic(0);
                volume.image.sprite = volumeSprites[0];
            }
            else
            {
                SaveData.SetSaveMusic(1);
                volume.image.sprite = volumeSprites[1];
            }
        }

        public void MusicSetup()
        {
            if (SaveData.GetMusic() == 1)
                volume.image.sprite = volumeSprites[1];
            else if (SaveData.GetMusic() == 0)
                volume.image.sprite = volumeSprites[0];
        }

    }
}


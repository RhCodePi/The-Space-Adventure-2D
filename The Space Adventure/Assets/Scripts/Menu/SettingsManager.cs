using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace rhcodepi
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] Button easyBtn, normalBtn, hardBtn;
        [SerializeField] Button standartBtn, challengeBtn;

        void Start()
        {
            if (SaveData.GetSaveEasy() == 1)
            {
                easyBtn.interactable = false;
                normalBtn.interactable = true;
                hardBtn.interactable = true;
            }
            if (SaveData.GetSaveNormal() == 1)
            {
                easyBtn.interactable = true;
                normalBtn.interactable = false;
                hardBtn.interactable = true;
            }
            if (SaveData.GetSaveHard() == 1)
            {
                easyBtn.interactable = true;
                normalBtn.interactable = true;
                hardBtn.interactable = false;
            }

            if (SaveData.GetStandard() == 1)
            {
                standartBtn.interactable = false;
                challengeBtn.interactable = true;
            }
            if (SaveData.GetChallenge() == 1)
            {
                standartBtn.interactable = true;
                challengeBtn.interactable = false;
            }
        }

        public void BackMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void SelectDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "easy":
                    SaveData.SetSaveEasy(1);
                    SaveData.SetSaveNormal(0);
                    SaveData.SetSaveHard(0);
                    easyBtn.interactable = false;
                    normalBtn.interactable = true;
                    hardBtn.interactable = true;
                    break;
                case "normal":
                    SaveData.SetSaveEasy(0);
                    SaveData.SetSaveNormal(1);
                    SaveData.SetSaveHard(0);
                    easyBtn.interactable = true;
                    normalBtn.interactable = false;
                    hardBtn.interactable = true;
                    break;
                case "hard":
                    SaveData.SetSaveEasy(0);
                    SaveData.SetSaveNormal(0);
                    SaveData.SetSaveHard(1);
                    easyBtn.interactable = true;
                    normalBtn.interactable = true;
                    hardBtn.interactable = false;
                    break;
                default:
                    break;
            }
        }

        public void SelectPlayMode(string playMode)
        {
            switch (playMode)
            {
                case "standard":
                    SaveData.SetSaveStandard(1);
                    SaveData.SetSaveChallenge(0);
                    standartBtn.interactable = false;
                    challengeBtn.interactable = true;
                    break;
                case "challenge":
                    SaveData.SetSaveStandard(0);
                    SaveData.SetSaveChallenge(1);
                    standartBtn.interactable = true;
                    challengeBtn.interactable = false;
                    break;
                default:
                    break;
            }
        }
    }
}


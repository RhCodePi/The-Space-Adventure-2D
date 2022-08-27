using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace rhcodepi
{
    public class HighScoreManager : MonoBehaviour
    {
        [SerializeField] Text headTxt, easyPuan, easyCoin, normalPuan, normalCoin, hardPuan, hardCoin;

        private void Start()
        {
            easyPuan.text = $"Puan {SaveData.GetSaveEasyPuan()}";
            easyCoin.text = $" X {SaveData.GetSaveEasyCoin()}";

            normalPuan.text = $"Puan {SaveData.GetSaveNormalPuan()}";
            normalCoin.text = $" X {SaveData.GetSaveNormalCoin()}";

            hardPuan.text = $"Puan {SaveData.GetSaveHardPuan()}";
            hardCoin.text = $" X {SaveData.GetSaveHardCoin()}";
        }

        public void BackMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}


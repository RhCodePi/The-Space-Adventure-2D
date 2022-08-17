using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace rhcodepi
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject inGameUI;
        [SerializeField] GameObject gameOverUI;
        [SerializeField] Text gameOverScoreTxt;
        [SerializeField] Text gameOverCoinTxt;
        [SerializeField] GameObject forAndroid;
        int score;
        int coinCount;
        // Start is called before the first frame update
        void Start()
        {
            gameOverUI.SetActive(false);
            inGameUI.SetActive(true);

            #if UNITY_EDITOR_WIN
                forAndroid.SetActive(false);
            #else
                forAndroid.SetActive(true);
            #endif
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("Game");
            inGameUI.SetActive(true);
            gameOverUI.SetActive(false);
        }

        public void SetGameOver()
        {
            FindObjectOfType<Sound>().SetGameOverSound();
            inGameUI.SetActive(false);
            gameOverScoreTxt.text = GetComponent<Score>().gameOverScoreTxt.text; 
            gameOverCoinTxt.text = GetComponent<Score>().gameOverCoinTxt.text;

            string[] subPuan = gameOverScoreTxt.text.Split(' ');
            string[] subCoin = gameOverCoinTxt.text.Split(' ');
            int result = 0;
            foreach (var item in subPuan)
            {
                if(int.TryParse(item, out result))
                    score = int.Parse(item);
            }
            foreach (var item in subCoin)
            {
                if(int.TryParse(item, out result))
                    coinCount = int.Parse(item);
            }
            CalculateHighScoreEachDifficult(score, coinCount);
            GetComponent<Score>()._isGameOver = true;
            FindObjectOfType<PlayerControl>().GameOver();
            gameOverUI.SetActive(true);
        }
        public void CalculateHighScoreEachDifficult(int score, int coinCount)
        {
            if (SaveData.GetSaveEasy() == 1)
            {
                int highScore = SaveData.GetSaveEasyPuan();
                int highCoin = SaveData.GetSaveEasyCoin();
                if(score > highScore)
                    SaveData.SetSaveEasyPuan(score);
                if(coinCount > highCoin)
                    SaveData.SetSaveEasyCoin(coinCount);
            }
            
            if (SaveData.GetSaveNormal() == 1)
            {
                int highScore = SaveData.GetSaveNormalPuan();
                int highCoin = SaveData.GetSaveNormalCoin();
                if(score > highScore)
                    SaveData.SetSaveNormalPuan(score);
                if(coinCount > highCoin)
                    SaveData.SetSaveNormalCoin(coinCount);
            }
            
            if (SaveData.GetSaveHard() == 1)
            {
                int highScore = SaveData.GetSaveHardPuan();
                int highCoin = SaveData.GetSaveHardCoin();
                if(score > highScore)
                    SaveData.SetSaveHardPuan(score);
                if(coinCount > highCoin)
                    SaveData.SetSaveHardCoin(coinCount);
            }
        }
    }
}

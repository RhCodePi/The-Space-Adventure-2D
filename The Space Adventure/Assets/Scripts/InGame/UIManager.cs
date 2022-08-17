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
        
        // Start is called before the first frame update
        void Start()
        {
            gameOverUI.SetActive(false);
            inGameUI.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

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
            inGameUI.SetActive(false);
            gameOverCoinTxt.text = GetComponent<Score>().gameOverCoinTxt.text;
            gameOverScoreTxt.text = GetComponent<Score>().gameOverScoreTxt.text;
            GetComponent<Score>()._isGameOver = true;
            gameOverUI.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rhcodepi
{
    public class Score : MonoBehaviour
    {
        int coinCount = 0;
        bool isGameOver;
        [SerializeField] Text scoreTxt;
        [SerializeField] Text coinTxt;
        public bool _isGameOver{
            set{
                isGameOver = value;
            }
        }
        void Start()
        {
            coinTxt.text = $"X {coinCount}";
        }

        // Update is called once per frame
        void Update()
        {
            if(!isGameOver) SetScore();
        }

        void SetScore()
        {
            int score = (int) Camera.main.transform.position.y;
            scoreTxt.text = $"Score : {score:D2}";
        }

        public void CollectCoin()
        {
            coinCount++;
            coinTxt.text = $"X {coinCount}";
        }

        public Text gameOverScoreTxt{
            get{
                return scoreTxt;
            }
        }

        public Text gameOverCoinTxt{
            get{
                return coinTxt;
            }
        }
    }
}


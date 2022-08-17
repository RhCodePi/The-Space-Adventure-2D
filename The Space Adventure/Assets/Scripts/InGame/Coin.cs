using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rhcodepi
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] GameObject coin;
        public void CoinEnable()
        {
            coin.SetActive(true);
        }
        public void CoinDisable()
        {
            coin.SetActive(false);
        }
    }
}


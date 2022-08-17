using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rhcodepi
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] GameObject coin;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

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


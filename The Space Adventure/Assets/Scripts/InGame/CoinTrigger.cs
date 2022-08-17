using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rhcodepi
{
    public class CoinTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.CompareTag("IsGround"))
            {
                GetComponentInParent<Coin>().CoinDisable();
                FindObjectOfType<Score>().CollectCoin();
            }
        }
    }
}


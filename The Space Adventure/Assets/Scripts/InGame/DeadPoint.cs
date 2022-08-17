using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rhcodepi
{
    public class DeadPoint : MonoBehaviour
    {

        public void DeadBound()
        {
            FindObjectOfType<UIManager>().SetGameOver();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace rhcodepi
{
    public class HighScoreManager : MonoBehaviour
    {
        public void BackMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}


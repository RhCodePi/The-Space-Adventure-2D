using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rhcodepi
{
    public class BackgroundMove : MonoBehaviour
    {
        float backgrondPos;
        float distance = 10.24f;
        // Start is called before the first frame update
        void Start()
        {
            backgrondPos = transform.position.y;
            FindObjectOfType<Planets>().SetPlanet(backgrondPos);
        }

        // Update is called once per frame
        void Update()
        {
            if (backgrondPos + distance < Camera.main.transform.position.y)
            {
                MoveBackground();
            }
        }

        void MoveBackground()
        {
            backgrondPos += (distance * 2);
            FindObjectOfType<Planets>().SetPlanet(backgrondPos);
            Vector2 newPos = new Vector2(0, backgrondPos);
            transform.position = newPos;
        }
    }
}


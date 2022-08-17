using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rhcodepi
{
    public class CameraMove : MonoBehaviour
    {
        float speed;
        float acceleration;
        float maxSpeed;
        private bool isMove;
        void Start()
        {
            if (SaveData.GetSaveEasy() == 1)
            {
                speed = 0.2f;
                acceleration = 0.02f;
                maxSpeed = 1.0f;
            }
            if (SaveData.GetSaveNormal() == 1)
            {
                speed = 0.5f;
                acceleration = 0.05f;
                maxSpeed = 2.0f;
            }
            if (SaveData.GetSaveHard() == 1)
            {
                speed = 0.8f;
                acceleration = 0.08f;
                maxSpeed = 2.5f;
            }
        }

        void Update()
        {
            if (!isMove) CalculationCamSpeed();
        }

        void CalculationCamSpeed()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            speed += acceleration * Time.deltaTime;
            if (speed > maxSpeed) speed = maxSpeed;
        }
    }
}


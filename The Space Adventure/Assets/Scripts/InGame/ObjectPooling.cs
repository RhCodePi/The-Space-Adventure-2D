﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rhcodepi
{
    public class ObjectPooling : MonoBehaviour
    {
        [SerializeField] GameObject platformPref;
        [SerializeField] GameObject enemyPlatformPref;
        [SerializeField] GameObject playerPref;
        [SerializeField] int platformCount;
        int enemyPlatCount = 1;
        [SerializeField] float distance = 3.0f; // each platform between distance 
        List<GameObject> platforms = new List<GameObject>();
        [SerializeField] Transform container;
        Vector2 platformPos;
        Vector2 playerPos;
        Vector2 enemyPlatPos;
        void Start()
        {
            GeneratePlatforms();
        }

        // Update is called once per frame
        void Update()
        {

            if (platforms[platformCount - 1].transform.position.y < Camera.main.transform.position.y + PlatformPath.instance.Height)
            {
                SetPlatform();
            }
        }

        void SetPlatform()
        {
            for (int i = 0; i < (int)platformCount / 2; i++)
            {
                GameObject temp;
                temp = platforms[i + (int)platformCount / 2];
                platforms[i + (int)platformCount / 2] = platforms[i];
                platforms[i] = temp;
                platforms[i + (int)platformCount / 2].transform.position = platformPos;


                if(platforms[i+(int)platformCount/2].gameObject.CompareTag("Platform"))
                {
                    platforms[i+(int)platformCount/2].GetComponent<Coin>().CoinDisable();
                    float randomCoin = Random.Range(0.0f, 1.0f);
                    if(randomCoin < 0.5f) platforms[i+(int)platformCount/2].GetComponent<Coin>().CoinEnable();
                }

                NextPlatformLocation();
            }
        }

        void GeneratePlatforms()
        {
            playerPos = new Vector2(0, 0.74f);
            platformPos = new Vector2(0, 0);

            GameObject player = Instantiate(playerPref, playerPos, Quaternion.identity);
            GameObject firstPlatform = Instantiate(platformPref, platformPos, Quaternion.identity, container);
            platforms.Add(firstPlatform);
            NextPlatformLocation();

            for (int i = 1; i < platformCount - enemyPlatCount; i++)
            {
                GameObject platform = Instantiate(platformPref, platformPos, Quaternion.identity, container);
                platforms.Add(platform);
                platform.GetComponent<Platform>().IsMove = true;
                if (i % 2 == 0)
                {
                    platform.GetComponent<Coin>().CoinEnable();
                }
                NextPlatformLocation();
            }
            GameObject enemyPlat = Instantiate(enemyPlatformPref, platformPos, Quaternion.identity, container);
            platforms.Add(enemyPlat);
            NextPlatformLocation();
        }

        void NextPlatformLocation()
        {
            platformPos.y += distance;
            float random = Random.Range(0.0f, 1.0f);
            if (random < 0.5f)
            {
                platformPos.x = PlatformPath.instance.Width / 2;
            }
            else
            {
                platformPos.x = -PlatformPath.instance.Width / 2;
            }
        }
    }
}


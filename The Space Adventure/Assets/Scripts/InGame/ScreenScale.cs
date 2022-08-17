using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rhcodepi
{
    public class ScreenScale : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] float xStuff;
        void Start()
        {
            ScreenScaleCal();
        }

        void Update()
        {

        }

        void ScreenScaleCal()
        {
            Vector2 tempScale = transform.localScale;
            float spriteWidth = spriteRenderer.size.x;
            float screenHeight = Camera.main.orthographicSize * xStuff;
            float screenWidth = screenHeight / Screen.width * Screen.height;

            tempScale.x = screenWidth / spriteWidth;

            transform.localScale = tempScale;
        }
    }
}

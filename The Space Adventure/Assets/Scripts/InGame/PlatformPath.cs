using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rhcodepi
{
    public class PlatformPath : MonoBehaviour
    {
        public static PlatformPath instance;
        float height, width;

        public float Width{
            get{return width;}
        }
        public float Height{
            get{return height;}
        }
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }

            height = Camera.main.orthographicSize;
            width = height * Camera.main.aspect; 
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


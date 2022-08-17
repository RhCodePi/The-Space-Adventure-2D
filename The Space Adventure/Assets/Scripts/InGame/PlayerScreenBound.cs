using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rhcodepi
{
    public class PlayerScreenBound : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if(transform.position.x < -PlatformPath.instance.Width)
            {
                Vector2 boundX = new Vector2(-PlatformPath.instance.Width, transform.position.y);
                transform.position = boundX;
            }
            else if(transform.position.x > PlatformPath.instance.Width)
            {
                Vector2 boundX = new Vector2(PlatformPath.instance.Width, transform.position.y);
                transform.position = boundX;
            }
        }
    }

}

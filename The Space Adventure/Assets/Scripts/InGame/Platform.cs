using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rhcodepi
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] PolygonCollider2D coll;
        float pingPongScale;
        float screenSize;
        float velocity;
        float min, max;
        bool isMove;
        public bool IsMove
        {
            get
            {
                return isMove;
            }
            set
            {
                isMove = value;
            }
        }
        void Start()
        {
            velocity = Random.Range(0.5f, 1.0f);
            if (transform.position.x > 0)
            {
                min = coll.bounds.size.x / 2;
                max = PlatformPath.instance.Width - coll.bounds.size.x / 2;

            }
            else
            {
                min = -PlatformPath.instance.Width + coll.bounds.size.x / 2;
                max = -coll.bounds.size.x / 2;
            }
        }

        void Update()
        {
            PlatformMove();
        }

        void PlatformMove()
        {
            if (isMove)
            {
                pingPongScale = Mathf.PingPong(Time.time * velocity, (max - min)) + min; // this variable pingpong between 0 and 5; 
                Vector2 pingpongPos = new Vector2(pingPongScale, transform.position.y);
                transform.position = pingpongPos;
            }
        }

        private void OnTriggerEnter2D(Collider2D _coll) {
            if(_coll.CompareTag("IsGround"))
            {
                GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerControl>().JumpCount = 0;
            }
        }
    }
}


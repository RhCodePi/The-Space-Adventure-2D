using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rhcodepi
{
    public class EnemyPlatform : MonoBehaviour
    {
        [SerializeField] BoxCollider2D coll;
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
            velocity = Random.Range(1, 3);
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

        private void OnTriggerEnter2D(Collider2D coll) {
            if(coll.CompareTag("IsGround"))
            {
                FindObjectOfType<UIManager>().SetGameOver();
            }
        }
    }
}


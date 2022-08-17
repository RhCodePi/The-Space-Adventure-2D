using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rhcodepi
{
    public class PlayerControl : MonoBehaviour
    {
        const float turningRotate = 180;
        [SerializeField] Rigidbody2D playerRb;
        [SerializeField] Animator playerAnim;
        [SerializeField] float speed;
        [SerializeField] float acceleration;
        [SerializeField] float deacceleration;
        [SerializeField] float jumpForce;
        [SerializeField] int jumpBound = 2;
        int jumpCount;
        Vector2 velocity;
        Joystick joystick;
        JumpButton jumpButton;
        bool onJump;
        public int JumpCount
        {
            set
            {
                jumpCount = value;
                FindObjectOfType<JumpSlider>().SetJumpSlider(jumpBound, jumpCount);
            }
        }
        void Start()
        {
            joystick = FindObjectOfType<Joystick>();
            jumpButton = FindObjectOfType<JumpButton>();
            
        }


        void Update()
        {
            #if UNITY_EDITOR
                PlayerMove();
            #else 
                JoystickControl();
            #endif
        }
        #region WindowsControl
        void PlayerMove()
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            if (inputX < 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, -inputX * speed, acceleration * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, turningRotate, 0);
                playerAnim.SetBool("walk", true);

            }
            else if (inputX > 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, inputX * speed, acceleration * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Quaternion.identity.eulerAngles);
                playerAnim.SetBool("walk", true);
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, deacceleration * Time.deltaTime);
                playerAnim.SetBool("walk", false);
            }
            transform.Translate(velocity * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpBegin();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                JumpEnd();
            }
        }
        #endregion
        
        #region AndroidControl
        void JoystickControl()
        {
            float inputX = joystick.Horizontal;
            if (inputX < 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, -inputX * speed, acceleration * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, turningRotate, 0);
                playerAnim.SetBool("walk", true);

            }
            else if (inputX > 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, inputX * speed, acceleration * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Quaternion.identity.eulerAngles);
                playerAnim.SetBool("walk", true);
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, deacceleration * Time.deltaTime);
                playerAnim.SetBool("walk", false);
            }
            transform.Translate(velocity * Time.deltaTime);

            if(jumpButton.IsJump && !onJump)
            {
                JumpBegin();
                onJump = true;
            }
            else if(!jumpButton.IsJump && onJump){
                JumpEnd();
                onJump = false;
            }
        }
        #endregion


        void JumpBegin()
        {
            if (jumpCount < jumpBound)
            {
                playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                playerAnim.SetBool("jump", true);
                FindObjectOfType<JumpSlider>().SetJumpSlider(jumpBound, jumpCount);
            }

        }
        void JumpEnd()
        {
            playerAnim.SetBool("jump", false);
            jumpCount++;
            FindObjectOfType<JumpSlider>().SetJumpSlider(jumpBound, jumpCount);
        }


        private void OnCollisionEnter2D(Collision2D coll) {
            if(coll.gameObject.CompareTag("DeadPoint"))
            {
                FindObjectOfType<DeadPoint>().DeadBound();
            }
        }

        public void GameOver()
        {
            Destroy(gameObject);
        }

    }
}



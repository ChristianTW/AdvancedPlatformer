using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RandularSystems.GamePlay2D
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCharacter2D : CharacterController2D
    {
        //public PlayerData Data;

        public float speed = 10.0f;
        public float collisionTestOffset = 0.5f;

        public SpriteRenderer spriteRenderer;
        public Animator animator;

        public bool isAlive = true;

        public bool isHit = false;

        public string currentScene;

        public bool isHurt = false;

        public void Death()
        {
            SceneManager.LoadScene(currentScene);
        }

        private Rigidbody2D m_rigidbody2D;
        // Why is Rigidbody 2D not named?
        void Start()
        {
            m_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            if(spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }
            animator = gameObject.GetComponent<Animator>();

            //SetGravityScale(Data.gravityScale);

            //_rigidbody = GetComponent<Rigidbody2D>();

        }


        //Jump code?
        /*
        public void Jump ()
        {
            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                motion.y = speed * 0.9f;
            }
        }
        */


        //On press check/ holding button check
        // Probably gonna replace this entirely with code from video
        /*
        public bool isHeldDown = false;
 
        public void OnPress ()
        {
            isHeldDown = true;
            Debug.Log(isHeldDown);
        }
 
            public void onRelease ()
        {
            isHeldDown = false;
            Debug.Log(isHeldDown);
        }
        */

        void Update()
        {
            if (isAlive == false)
            {
                return;
            }
            float xInput = Input.GetAxis("Horizontal");
            isTouchingGround = IsTouchingGround();
            
            Vector2 motion = m_rigidbody2D.velocity;

            if (xInput != 0.0f)
            {
                if (!TestMove(Vector2.right, collisionTestOffset) && xInput > 0.0f)
                {
                    motion.x = -xInput * (speed * 0.01f);
                } else if (!TestMove(Vector2.left, collisionTestOffset) && xInput < 0.0f)
                {
                    motion.x = -xInput * (speed * 0.01f);
                } else
                {
                    motion.x = xInput * speed;
                }
                
            }

            //Jump Code?
            /*
            var inputX = Input.GetAxisRaw("Horizontal");
            //var jumpInput = Input.GetButtonDown("Jump");
            var jumpInputRelease = Input.GetButtonUp("Jump");

            //m_rigidbody2D.velocity = new Vector2( inputX * _movementVel, m_rigidbody2D.velocity.y);

            //if (jumpInput && IsTouchingGround)
            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, 8);
                //m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, _jumpVel);
            }

            if (jumpInputRelease && m_rigidbody2D.velocity.y > 0)
            {
                m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, 0);
            }

            if (inputX != 0)
            {
                transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
            }
            */


            //Will be where I call jump
            
            //var jumpInputRelease = Input.GetButtonUp("Jump");

            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                motion.y = speed * 1.0f;
            }

            if (Input.GetButtonUp("Jump") && !isTouchingGround)
            {
                motion.y = 0.0f;
            }
            
            /*
            if (m_rigidbody2D.velocity < 0)
            {
                m_rigidbody2D.gravityScale = Data.gravityScale * 1.5f;
            }
            */


            if (animator != null)
            {
                animator.SetFloat("SpeedX", Mathf.Abs(motion.x));
                animator.SetFloat("SpeedY", motion.y);
                animator.SetBool("Grounded", isTouchingGround);
            }

            if (spriteRenderer != null)
            {
                if (motion.x > 0.01f)
                {
                    spriteRenderer.flipX = true;
                    // Was false, new sprite is facing other way
                }
                if (motion.x < -0.01f)
                {
                    spriteRenderer.flipX = false;
                    // Was true, new sprite is facing other way
                }
            }

            m_rigidbody2D.velocity = motion;
        }

        public void OnHurt()
        {
            animator.SetTrigger("IsHurt");
            isHurt = true;
        }
    }
}

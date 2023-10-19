using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RandularSystems.GamePlay2D
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCharacter2D : CharacterController2D
    {
        public float speed = 10.0f;
        public float collisionTestOffset = 0.5f;

        public SpriteRenderer spriteRenderer;
        public Animator animator;

        public bool isAlive = true;

        public int jumpCount = 2;

        public bool isHit = false;

        public string currentScene;

        public bool isHurt = false;

        public void Death()
        {
            SceneManager.LoadScene(currentScene);
        }

        private Rigidbody2D m_rigidbody2D;
        void Start()
        {
            m_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            if(spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }
            animator = gameObject.GetComponent<Animator>();
        }
        void Update()
        {
            if (isAlive == false)
            {
                return;
            }
            float xInput = Input.GetAxis("Horizontal");
            isTouchingGround = IsTouchingGround();
            if (IsTouchingGround())
            {
                jumpCount = 1;
            }
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

            if (Input.GetAxis("Jump") > 0.0f && isTouchingGround)
            {
                motion.y = speed * 0.9f;
            } 
            else if (Input.GetKeyDown("space") && !isTouchingGround && jumpCount > 0)
            {
                motion.y = speed * 0.8f;
                jumpCount = jumpCount - 1;
            }

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
                    spriteRenderer.flipX = false;
                }
                if (motion.x < -0.01f)
                {
                    spriteRenderer.flipX = true;
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

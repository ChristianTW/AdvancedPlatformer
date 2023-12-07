using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        public bool isHit = false;

        public string currentScene;

        public bool isHurt = false;

        public bool canMove = true;


        public GameObject RestartThing;
        
        
        public void Death()
        {
            isAlive = false;
        }
        

        private Rigidbody2D m_rigidbody2D;
        // Why is Rigidbody 2D named M_rigidbody2D?
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
                //SceneManager.LoadScene("SampleScene");
                canMove = false;
                RestartThing.SetActive(true);
            }

            float xInput = Input.GetAxis("Horizontal");
            isTouchingGround = IsTouchingGround();
            
            Vector2 motion = m_rigidbody2D.velocity;

            if (xInput != 0.0f && canMove == true)
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

            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                motion.y = speed * 1.0f;
            }

            if (Input.GetButtonUp("Jump") && !isTouchingGround && motion.y > 0.0f)
            {
                motion.y = 0.0f;
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

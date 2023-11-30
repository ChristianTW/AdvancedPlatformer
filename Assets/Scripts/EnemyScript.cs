using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using RandularSystems.GamePlay2D;

public class EnemyScript : CharacterController2D
{

        public float enemySpeed = 10.0f;

        private bool movingRight = true;

        public bool isHurt = false;

        public bool canMove = true;

        public Transform wallDetection;
        
        public float collisionTestOffset = 0.5f;

        public SpriteRenderer spriteRenderer;
        public Animator animator;

        public bool isAlive = true;

        private Rigidbody2D rb;


    // Start is called before the first frame update
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
            if(spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }
            animator = gameObject.GetComponent<Animator>();
    }
    
    /*
    public void OnTriggerEnter2D(Collider2D ground)
        {
            if (movingRight == true)
            {
                //transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                //transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        */

    // Update is called once per frame
    void Update()
    {
        Vector2 motion = rb.velocity;

        if (isTouchingGround == true) {
            transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
        }
        
        if (canMove == true)
            {
                if (!TestMove(Vector2.right, collisionTestOffset) && movingRight == true)
                {
                    movingRight = false;
                } else if (!TestMove(Vector2.left, collisionTestOffset) && movingRight == false)
                {
                    movingRight = true;
                }/* else
                {
                    motion.x = xInput * speed;
                }
                */
                
            }

        if (isAlive == false)
        {
            enemySpeed = 0.0f;
        }

        if (spriteRenderer != null)
            {
                if (movingRight == true)
                {
                    spriteRenderer.flipX = true;
                    // Was false, new sprite is facing other way
                }
                if (movingRight == false)
                {
                    spriteRenderer.flipX = false;
                    // Was true, new sprite is facing other way
                }
            }
        /*
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
            */
        
        
    }
}

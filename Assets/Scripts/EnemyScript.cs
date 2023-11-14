using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using RandularSystems.GamePlay2D;

public class EnemyScript : MonoBehaviour
{

        public float enemySpeed = 10.0f;
        public float collisionTestOffset = 0.5f;

        public SpriteRenderer spriteRenderer;
        public Animator animator;

        public bool isAlive = true;

        //public bool isHit = false;

        //public string currentScene;

        //public bool isHurt = false;


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

    // Update is called once per frame
    void Update()
    {

        Vector2 motion = rb.velocity;
        
        if (isAlive == true)
        {
            motion.x = enemySpeed * 1.0f;
        }
        
    }
}

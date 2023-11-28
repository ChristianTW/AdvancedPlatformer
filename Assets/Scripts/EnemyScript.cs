using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using RandularSystems.GamePlay2D;

public class EnemyScript : MonoBehaviour
{

        public float enemySpeed = 10.0f;
        public float distance;

        private bool movingRight = true;

        //public Transform groundDetection;

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
    

    // Update is called once per frame
    void Update()
    {

        
        //transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

        //RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, 2f);
 
        /*
        if(wallInfo.collider.tag == "Wall")
        {
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        */

        /*
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false){
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        */
        
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
        
        
    }
}

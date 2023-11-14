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

        public bool isHit = false;

        public string currentScene;

        public bool isHurt = false;


        Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = transform.right * enemySpeed;
    }
}

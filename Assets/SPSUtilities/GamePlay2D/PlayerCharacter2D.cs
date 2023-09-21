using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RandularSystems.GamePlay2D
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCharacter2D : CharacterController2D
    {
        public float speed = 10.0f;
        public float collisionTestOffset = 0.5f;

        public SpriteRenderer spriteRenderer;
        public Animator animator;

        private Rigidbody2D m_rigidbody2D;
        void Start()
        {
            m_rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        }
        void Update()
        {
            float xInput = Input.GetAxis("Horizontal");
            isTouchingGround = IsTouchingGround();
            Vector2 motion = m_rigidbody2D.velocity;

            if (xInput != 0.0f)
            {
                motion.x = xInput * speed;
            }

            m_rigidbody2D.velocity = motion;
        }
    }
}

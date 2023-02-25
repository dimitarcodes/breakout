using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace group1.Breakout.Scripts //change this to your own directory
{
    [RequireComponent(typeof(Rigidbody))]
    public class Paddle : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float left, right, speed;
        private bool inBoundsLeft, inBoundsRight;

        private void Start()
        {
            inBoundsLeft = true;
            inBoundsRight = true;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
        }

        private void Reset()
        {
            left = -3f;
            right = 3f;
            speed = 12f;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow) && inBoundsLeft) 
            {
                transform.position += -transform.right * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow) && inBoundsRight)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }

            inBoundsRight = transform.position.x <= right;
            inBoundsLeft = transform.position.x > left;
        }
    }
}
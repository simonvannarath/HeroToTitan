using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarFox
{
    public class Laser : MonoBehaviour
    {
        public GameObject firePrefab; // Sound
        public Vector3 direction;
        public float damage = 25f;
        public float speed = 300f;
        public float lifetime = 5f;
        public float shootRate = 0.175f;

        [HideInInspector]
        public Transform owner;

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, lifetime);
        }

        // Update is called once per frame
        void Update()
        {
            if (direction.magnitude != 0)
            {
                transform.rotation = Quaternion.LookRotation(direction); // Only call 'LookRotation' if vector is not zero
            }
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}


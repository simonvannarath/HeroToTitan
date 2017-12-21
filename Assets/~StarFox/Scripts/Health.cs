﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarFox
{
    public class Health : MonoBehaviour
    {
        public float health = 100f;

        // Update is called once per frame
        void Update()
        {
            // TEMPORARY!
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        public void DealDamage(float damage)
        {
            health -= damage;
        }

    }
}



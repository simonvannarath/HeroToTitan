﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperMarioGalaxy
{
    public class Rotate : MonoBehaviour
    {
        public Vector3 speed = Vector3.zero;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(speed * Time.deltaTime);
        }
    }
}


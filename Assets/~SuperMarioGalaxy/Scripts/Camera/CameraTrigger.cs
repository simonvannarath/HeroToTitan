﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperMarioGalaxy
{
    public class CameraTrigger : MonoBehaviour
    {
        public CameraNode[] nodes;
        [Header("Debugging")]
        public bool debug = false;
        public float nodeRadius = 1f;


        // Use this for initialization
        void Start()
        {
            nodes = GetComponentsInChildren<CameraNode>();
        }

        private void OnDrawGizmos()
        {
            if (debug)
            {
                nodes = GetComponentsInChildren<CameraNode>();
                Gizmos.DrawSphere(transform.position, nodeRadius);

                foreach (CameraNode node in nodes)
                {
                    Gizmos.DrawSphere(node.transform.position, nodeRadius);
                }
            }
        }

        public CameraNode GetClosestNode(Vector3 position)
        {
            float minDistance = float.MaxValue;
            CameraNode closest = null;

            foreach (CameraNode node in nodes)
            {
                float distance = Vector3.Distance(node.transform.position, position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = node;
                }
            }
            return closest;
        }
    }
}


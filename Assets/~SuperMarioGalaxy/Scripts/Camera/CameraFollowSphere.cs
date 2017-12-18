using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperMarioGalaxy
{
    public class CameraFollowSphere : MonoBehaviour
    {
        public GravityBody target;
        public Vector3 offset = new Vector3(0, 0, -20);
        public float speed = 5f;
        public float sphereRadius = 5f;

        private Vector3 centerPos; // Camera center

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(centerPos, sphereRadius);    
        }

        // Use this for initialization
        void Start()
        {
            centerPos = target.transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // Is there a valid target?
            if(target != null)
            {
                float distance = Vector3.Distance(centerPos, target.transform.position);
                // Is target's distance further from center of sphere?
                if(distance > sphereRadius)
                {
                    // Move center to new target pos
                    centerPos = Vector3.Lerp(centerPos, target.transform.position, speed * Time.deltaTime);
                }

                Vector3 worldOffset = Quaternion.LookRotation(target.Gravity) * offset;
                transform.position = Vector3.Lerp(transform.position, 
                                                  centerPos + worldOffset, speed * Time.deltaTime);
                transform.LookAt(target.transform, transform.up);
            }
        }
    }
}
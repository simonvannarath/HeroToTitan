using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarFox
{
    public class ArwingShoot : MonoBehaviour
    {
        //public Transform barrel;
        public GameObject muzzelFlashPrefab;
        [Header("Laser")]
        public Laser[] laserPrefabs;

        [Header("Pulse")]
        public GameObject lockOnUI;
        public GameObject chargeEffectPrefab;
        public GameObject fireEffectPrefab;
        public float chargeDelay = 1f;

        private int currentLaser = 0;
        private float shootTimer = 0f;

        // Update is called once per frame
        void Update()
        {
            shootTimer += Time.deltaTime;
        }

        GameObject FireLaser()
        {
            GameObject clone = Instantiate(laserPrefabs[currentLaser].gameObject); // Instantiate the current laser selected
            clone.transform.position = transform.position; // Set position and rotation of bullet to Arwing
            clone.transform.position = transform.position;
            Laser laser = clone.GetComponent<Laser>(); // Set direction of the laser
            laser.direction = transform.forward;
            laser.owner = transform; // Set owner to self
            return clone;
        }

        public GameObject Shoot()
        {
            Laser laserToShoot = laserPrefabs[currentLaser];

            if (shootTimer >= laserToShoot.shootRate)
            {
                shootTimer = 0f;
                return FireLaser();
            }
            return null;
        }
    }

}

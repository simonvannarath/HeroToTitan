using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace StarFox
{
    public class NetworkUserControl : NetworkBehaviour
    {
        public ArwingController controller;
        public ArwingShoot weapon;

        [Header("References")]
        public Camera cam;
        public AudioListener audioListener;
        public GameObject canvas;

        // Use this for initialization
        void Start()
        {
            // If we are not the local player
            if (!isLocalPlayer)
            {
                // Disable all references
                cam.enabled = false;
                audioListener.enabled = false;
                canvas.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Check if player is local player
            if (isLocalPlayer)
            {
                float inputH = Input.GetAxis("Horizontal");
                float inputV = Input.GetAxis("Vertical");
                controller.Move(inputH, inputV);

                // Check if local user pressed mouse button
                if (Input.GetMouseButton(0))
                {
                    GameObject laser = weapon.Shoot(); // Try to shoot laser

                    // Has the laser fired?
                    if (laser != null)
                    {
                        // Spawn on network
                    }
                }
            }
        }
    }
}


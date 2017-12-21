using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace StarFox
{
    public class SyncTransform : NetworkBehaviour
    {
        public Transform objectToSync;
        public bool isLocal = false;
        public float lerpSpeed = 10f;
        [SyncVar]
        public Vector3 position;
        [SyncVar]
        public Quaternion rotation;


        // What to do if the Client is the local player
        [Command]
        void Cmd_UpdatePosition(Vector3 position)
        {
            this.position = position;
        }

        [Command]
        void Cmd_UpdateRotation(Quaternion rotation)
        {
            this.rotation = rotation;
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                if (isLocal)
                {
                    // Send our position & rotation
                    Cmd_UpdatePosition(objectToSync.localPosition);
                    Cmd_UpdateRotation(objectToSync.localRotation);
                }

                else
                {
                    // Send our position & rotation
                    Cmd_UpdatePosition(objectToSync.position);
                    Cmd_UpdateRotation(objectToSync.rotation);
                }

            }

            else // ... if not
            {
                // Lerp out position & rotation
                LerpPosition();
                LerpRotation();
            }
        }

        // What to do if the Client is not local player
        void LerpPosition()
        {
            if (isLocal)
            {
                objectToSync.localPosition = Vector3.Lerp(objectToSync.localPosition, position, lerpSpeed * Time.deltaTime);
            }
            else
            {
                objectToSync.position = Vector3.Lerp(objectToSync.position, position, lerpSpeed * Time.deltaTime);
            }
        }
        void LerpRotation()
        {
            if (isLocal)
            {
                objectToSync.localRotation = Quaternion.Lerp(objectToSync.localRotation, rotation, lerpSpeed * Time.deltaTime);
            }
            else
            {
                objectToSync.rotation = Quaternion.Lerp(objectToSync.rotation, rotation, lerpSpeed * Time.deltaTime);
            }
        }
    }
}

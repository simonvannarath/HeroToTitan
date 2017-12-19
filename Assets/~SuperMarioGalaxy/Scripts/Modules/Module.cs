using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperMarioGalaxy
{
    public class Module : MonoBehaviour
    {

        public delegate void EventCallback();
        public delegate void ActionCallback(GravityBody body);

        public EventCallback onEnter;
        public EventCallback onStay;
        public EventCallback onExit;

        public ActionCallback onAction;


        public virtual void Enter()
        {
            // Check for subscribed functions
            if (onEnter != null)
            {
                onEnter.Invoke();
            }
        }

        public virtual void Stay()
        {
            // Check for subscribed functions
            if (onStay != null)
            {
                onStay.Invoke();
            }
        }

        public virtual void Exit()
        {
            // Check for subscribed functions
            if (onExit != null)
            {
                onExit.Invoke();
            }
        }

        public virtual void Action(GravityBody body)
        {
            if (onAction != null)
            {
                onAction.Invoke(body);
            }
        }
    }
}

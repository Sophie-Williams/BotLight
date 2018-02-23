using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BotLight
{
    public class BotMovement : MonoBehaviour
    {
        public float speed = 12f;                 // How fast the bot moves forward and back.
        public float turnSpeed = 180f;            // How fast the bot turns in degrees per second.
        
        [HideInInspector] public NavMeshAgent navMeshAgent;
        private new Rigidbody rigidbody;              // Reference used to move the bot.
        private Vector3 direction;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.speed = 40;

        }

        private Vector3 RandomNavSphere(Vector3 origin)
        {
            Vector3 randomDirection = Random.insideUnitSphere * Random.Range(15,40);
            randomDirection.y = 0;
            randomDirection += origin;
            return randomDirection;
        }


        public void SetupAI(bool aiActivationFromParent)
        {
            if (aiActivationFromParent)
            {
                navMeshAgent.enabled = true;
            }
            else
            {
                navMeshAgent.enabled = false;
            }
        }

        private void OnEnable()
        {
            // When the bot is turned on, make sure it's not kinematic.
            rigidbody.isKinematic = false;
            
        }


        private void OnDisable()
        {
            // When the bot is turned off, set it to kinematic so it stops moving.
            rigidbody.isKinematic = true;
        }


        public void Move(Vector3 destination)
        {
            navMeshAgent.destination = destination;
        }


        public void MoveRandom()
        {
            if (navMeshAgent.enabled)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
                {

                    direction = RandomNavSphere(this.transform.position);
                    navMeshAgent.destination = direction;
                }
            }
        }
    }
}
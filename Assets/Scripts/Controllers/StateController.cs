using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BotLight
{
    public class StateController : MonoBehaviour
    {

        public State currentState;
        public SphereParameters sphereParameters;
        public Transform eyes;
        public State remainState;


        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public List<Transform> wayPointList;
        [HideInInspector] public int nextWayPoint;
        [HideInInspector] public Transform food;
        [HideInInspector] public Transform chaseTarget;
        [HideInInspector] public float stateTimeElapsed;

        private bool aiActive;


        void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.stoppingDistance = 100; // ????
            navMeshAgent.speed = 40;
            // If "Failed to create agent because it is not close enough to the NavMesh" appears
            // that's because the object linked with nma is too far from the floor for example
        }

        public void SetupAI(bool aiActivationFromGameManager, List<Transform> wayPointsFromGameManager)
        {
            wayPointList = wayPointsFromGameManager;
            aiActive = aiActivationFromGameManager;
            if (aiActive)
            {
                navMeshAgent.enabled = true;
            }
            else
            {
                navMeshAgent.enabled = false;
            }
        }

        void Update()
        {
            if (!aiActive)
                return;
            currentState.UpdateState(this);
        }

        void OnDrawGizmos()
        {
            if (currentState != null && eyes != null)
            {
                Gizmos.color = currentState.sceneGizmoColor;
                Gizmos.DrawWireSphere(eyes.position, sphereParameters.lookSphereCastRadius);
            }
        }

        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }

    }
}
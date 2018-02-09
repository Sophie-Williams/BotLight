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


        
        [HideInInspector] public BotAttack botAttack;
        [HideInInspector] public BotHealth botHealth;
        [HideInInspector] public BotMovement botMovement;
        [HideInInspector] public Transform food;
        [HideInInspector] public Transform chaseTarget;
        [HideInInspector] public float stateTimeElapsed;

        private bool aiActive;


        void Awake()
        {
            botAttack = GetComponent<BotAttack>(); // TODO : Pass sphereParameters to components
            botHealth = GetComponent<BotHealth>();
            botMovement = GetComponent<BotMovement>();
            

            // If "Failed to create agent because it is not close enough to the NavMesh" appears
            // that's because the object linked with nma is too far from the floor for example
        }

        public bool SetupAI(bool aiActivationFromGameManager)
        {
            aiActive = aiActivationFromGameManager;
            return aiActive;
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
            Debug.Log("Countdown : " + stateTimeElapsed);
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }

    }
}
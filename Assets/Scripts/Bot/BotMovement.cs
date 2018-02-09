using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BotLight
{
    public class BotMovement : MonoBehaviour
    {
        public int botNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.
        public float speed = 12f;                 // How fast the tank moves forward and back.
        public float turnSpeed = 180f;            // How fast the tank turns in degrees per second.
        
        [HideInInspector] public NavMeshAgent navMeshAgent;
        // public AudioSource m_MovementAudio;         // Reference to the audio source used to play engine sounds. NB: different to the shooting audio source.
        // public AudioClip m_EngineIdling;            // Audio to play when the tank isn't moving.
        // public AudioClip m_EngineDriving;           // Audio to play when the tank is moving.
        // public float m_PitchRange = 0.2f;           // The amount by which the pitch of the engine noises can vary.

        //private string movementAxisName;          // The name of the input axis for moving forward and back.
        //private string turnAxisName;              // The name of the input axis for turning.
        private new Rigidbody rigidbody;              // Reference used to move the tank.
        // private float m_MovementInputValue;         // The current value of the movement input.
        // private float m_TurnInputValue;             // The current value of the turn input.
        //private float originalPitch;              // The pitch of the audio source at the start of the scene.
        //private ParticleSystem[] particleSystems; // References to all the particles systems used by the Tanks
        private Vector3 direction;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            //navMeshAgent.stoppingDistance = 100; // ????
            navMeshAgent.speed = 40;

        }

        void Start()
        {

            
        }

        private Vector3 RandomNavSphere(Vector3 origin)
        {
            Vector3 randomDirection = Random.insideUnitSphere * Random.Range(5,30);
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
            // When the tank is turned on, make sure it's not kinematic.
            rigidbody.isKinematic = false;

            // Also reset the input values.
            // m_MovementInputValue = 0f;
            // m_TurnInputValue = 0f;

            // We grab all the Particle systems child of that Tank to be able to Stop/Play them on Deactivate/Activate
            // It is needed because we move the Tank when spawning it, and if the Particle System is playing while we do that
            // it "think" it move from (0,0,0) to the spawn point, creating a huge trail of smoke
            /*
            particleSystems = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < particleSystems.Length; ++i)
            {
                particleSystems[i].Play();
            }
            */
        }


        private void OnDisable()
        {
            // When the tank is turned off, set it to kinematic so it stops moving.
            rigidbody.isKinematic = true;

            // Stop all particle system so it "reset" it's position to the actual one instead of thinking we moved when spawning
            /*
            for (int i = 0; i < particleSystems.Length; ++i)
            {
                particleSystems[i].Stop();
            }
            */
        }


        //private void Start()
        //{
            // The axes names are based on player number.
            // m_MovementAxisName = "Vertical" + m_PlayerNumber;
            // m_TurnAxisName = "Horizontal" + m_PlayerNumber;

            // Store the original pitch of the audio source.
            // m_OriginalPitch = m_MovementAudio.pitch;
        //}


        private void Update()
        {
            // Store the value of both input axes.
            // m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
            // m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

            // EngineAudio();
        }

        /*
        private void EngineAudio()
        {
            // If there is no input (the tank is stationary)...
            if (Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
            {
                // ... and if the audio source is currently playing the driving clip...
                if (m_MovementAudio.clip == m_EngineDriving)
                {
                    // ... change the clip to idling and play it.
                    m_MovementAudio.clip = m_EngineIdling;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play();
                }
            }
            else
            {
                // Otherwise if the tank is moving and if the idling clip is currently playing...
                if (m_MovementAudio.clip == m_EngineIdling)
                {
                    // ... change the clip to driving and play.
                    m_MovementAudio.clip = m_EngineDriving;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play();
                }
            }
        }*/


        private void FixedUpdate()
        {
            // Adjust the rigidbodies position and orientation in FixedUpdate.
            // Move();
            // Turn();
        }


        public void Move()
        {
            //Debug.Log("move : "+this.transform.position);
            if (navMeshAgent.enabled)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
                {

                    direction = RandomNavSphere(this.transform.position);
                    navMeshAgent.destination = direction;
                }
            }
        }


        private void Turn()
        {
            // Determine the number of degrees to be turned based on the input, speed and time between frames.
            // float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            // Make this into a rotation in the y axis.
            // Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            // Apply this rotation to the rigidbody's rotation.
            // m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
        }
    }
}
using UnityEngine;
using System.Collections;

namespace BotLight
{

    public class PlayerController : MonoBehaviour
    {


        private Rigidbody rb;


        public float inputDelay = 0.1f;
        public float forwardVel = 120;
        public float rotateVel = 100;

        Quaternion targetRotation;
        float forwardInput, turnInput, attackInput;

        public Quaternion TargetRotation
        {
            get { return targetRotation; }
        }

        void Start()
        {
            targetRotation = transform.rotation;
            if (GetComponent<Rigidbody>())
                rb = GetComponent<Rigidbody>();
            else
                Debug.LogError("The character needs a rigidbody.");

            forwardInput = turnInput = 0;
        }

        void GetInput()
        {
            forwardInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");
            attackInput = Input.GetAxis("Fire1");
        }

        void Update()
        {
            GetInput();
            Attack();
            Turn();
        }

        private void FixedUpdate()
        {
            Run();
        }

        void Attack()
        {


            if (attackInput > 0)
            {
                RaycastHit hit;

                //Debug.Log("Click");
                Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
                if (Physics.SphereCast(origin, 10, transform.forward, out hit, 10, LayerMask.GetMask("Eatable")) && hit.rigidbody.tag != "StaticEatable")
                {
                    Debug.Log("Attack");
                    BotAttack BotAttack = GetComponent<BotAttack>();
                    BotAttack.Attack(1, hit);
                }
            }
        }

        void Run()
        {
            if (Mathf.Abs(forwardInput) > inputDelay)
            {
                rb.velocity = transform.forward * forwardInput * forwardVel;
            }
            else
                rb.velocity = Vector3.zero;
        }
        void Turn()
        {
            if (Mathf.Abs(turnInput) > inputDelay)
            {
                targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
            }
            transform.rotation = targetRotation;
        }
    }
}
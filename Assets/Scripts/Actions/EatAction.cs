using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Actions/Eat")]
    public class EatAction : Action
    {
        private IEnumerator coroutine;

        public override void Act(StateController controller)
        {
            
            Eat(controller);
        }

        private void Eat(StateController controller)
        {
            if (controller.food)
            {
                controller.botMovement.navMeshAgent.destination = controller.food.position;
                // Animation
                controller.botMovement.navMeshAgent.isStopped = false; // ~= Resume() (deprecated)

                Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.sphereParameters.lookRange, Color.green);
                // Doesn't draw any line ray ?


                //Debug.Log("Entered LookDecision - herbivorous");
                Collider[] hitColliders = Physics.OverlapSphere(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, LayerMask.GetMask("Eatable"));

                // search through all hit colliders for an eatable
                for (var i = 0; i < hitColliders.Length; i++)
                {
                    if (hitColliders[i].transform.tag == "StaticEatable")
                    {
                        Debug.Log("Eat");
                        hitColliders[i].gameObject.GetComponent<Food>().GetEaten(1); // we saw food at hit.transform position => assign to food position
                    }
                }
            }
        }
    }
}
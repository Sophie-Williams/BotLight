using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Decisions/Look")]
    public class LookDecision : Decision
    {

        public override bool Decide(StateController controller)
        {
            //Debug.Log("LookDecision");
            bool foodVisible = Look(controller); // food visible ?
            return foodVisible;
        }

        private bool Look(StateController controller)
        {
            // TODO : Nothing detected, maybe try manual detecting ?

            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.sphereParameters.lookRange, Color.green);
            // Doesn't draw any line ray ?

            if (controller.sphereParameters.diet == Diet.CARNIVOROUS)
            {
                RaycastHit hit;


                // SphereCast is used to detect moving object, so prob only for carnivorous animals
                // only detect collider with Eatable layer => huge optimisation
                if (Physics.SphereCast(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, controller.eyes.forward, out hit, controller.sphereParameters.lookRange, LayerMask.GetMask("Eatable")))
                {
                    Debug.Log("LookDecision - carnivorous - saw eatable");
                    controller.chaseTarget = hit.transform;
                    controller.food = controller.chaseTarget;
                    // maybe AI saw something ... (food ...) ?
                    // or aggressive AI, attack when see smthing
                    return true;
                }
            }

            else if (controller.sphereParameters.diet == Diet.HERBIVOROUS)
            {
                //Debug.Log("Entered LookDecision - herbivorous");
                Collider[] hitColliders = Physics.OverlapSphere(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, LayerMask.GetMask("Eatable"));

                // search through all hit colliders for an eatable
                for (var i = 0; i < hitColliders.Length; i++)
                {
                    Debug.Log("LookDecision - herbivorous - saw eatable");
                    controller.food = hitColliders[i].transform; // we saw food at hit.transform position => assign to food position

                    return true; // we found an eatable. exit early
                }
            }
            return false; // looked through all hit colliders but none was an eatable

        }
    }
}
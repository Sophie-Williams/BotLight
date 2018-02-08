using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Decisions/LookNonStaticDecision")]
    public class LookNonStaticDecision : Decision
    {

        public override bool Decide(StateController controller)
        {
            bool animalVisible = Look(controller);
            return animalVisible;
        }

        private bool Look(StateController controller)
        {
            // TODO : Nothing detected, maybe try manual detecting ?

            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.sphereParameters.lookRange, Color.green);
            // Doesn't draw any line ray ?


            RaycastHit hit;


            // SphereCast is used to detect moving object, so prob only for carnivorous animals
            // only detect collider with Eatable layer => huge optimisation
            if (Physics.SphereCast(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, controller.eyes.forward, out hit, controller.sphereParameters.lookRange, LayerMask.GetMask("Eatable")) && hit.rigidbody.tag != "StaticEatable")
            {
                //Debug.Log("LookForAnimalDecision - saw eatable");
                controller.chaseTarget = hit.transform;
                //controller.food = controller.chaseTarget;
                // maybe AI saw something ... (food ...) ?
                // or aggressive AI, attack when see smthing
                return true;
            }
            

            return false; // looked through all hit colliders but none was an eatable

        }
    }
}
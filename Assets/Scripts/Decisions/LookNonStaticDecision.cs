using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Decisions/LookNonStatic")]
    public class LookNonStaticDecision : Decision
    {

        public override bool Decide(StateController controller)
        {
            bool animalVisible = Look(controller);
            return animalVisible;
        }

        private bool Look(StateController controller)
        {
            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.sphereParameters.lookRange, Color.green);
            


            RaycastHit hit;


            // SphereCast is used to detect moving object, so prob only for carnivorous animals
            // only detect collider with Eatable layer => huge optimisation
            if (Physics.SphereCast(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, controller.eyes.forward, out hit, controller.sphereParameters.lookRange, LayerMask.GetMask("Eatable")) && hit.rigidbody.tag != "StaticEatable")
            {
                controller.chaseTarget = hit.transform;
                return true;
            }
            

            return false; // looked through all hit colliders but none was an eatable

        }
    }
}
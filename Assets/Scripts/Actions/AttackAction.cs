using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Actions/Attack")]
    public class AttackAction : Action
    {
        
        public override void Act(StateController controller)
        {
            Attack(controller);
        }

        private void Attack(StateController controller)
        {
            RaycastHit hit;

            //Vector3 castOrigin = new Vector3(controller.eyes.position.x - controller.sphereParameters.lookSphereCastRadius * 2, controller.eyes.position.y, controller.eyes.position.z - controller.sphereParameters.lookSphereCastRadius * 2);
            Vector3 castOrigin = controller.eyes.position - controller.eyes.forward * controller.sphereParameters.lookSphereCastRadius * 2;
            //Debug.Log("Origin : " + castOrigin.z);
            Debug.DrawRay(castOrigin, controller.eyes.forward.normalized * controller.sphereParameters.attackRange, Color.red);

            if (Physics.SphereCast(castOrigin, controller.sphereParameters.lookSphereCastRadius, controller.eyes.forward, out hit, controller.sphereParameters.attackRange, LayerMask.GetMask("Eatable")) && hit.rigidbody.tag != "StaticEatable")
            {
                //StateController target = hit.rigidbody.GetComponent<StateController>();

                //Debug.Log("Hit : "+hit);
                controller.botAttack.Attack(controller.sphereParameters.attackRate, hit);
            }
            else
            {
                //Debug.Log("Not hit");
            }
        }
    }
}

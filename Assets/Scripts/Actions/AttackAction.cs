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

            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.sphereParameters.attackRange, Color.red);
            
            if (Physics.SphereCast(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, controller.eyes.forward, out hit, controller.sphereParameters.attackRange, LayerMask.GetMask("Eatable")) && hit.rigidbody.tag != "StaticEatable")
            {

                    StateController target = hit.rigidbody.GetComponent<StateController>();

                    controller.botAttack.Attack(controller.sphereParameters.attackRate, target);
                   
                    
                    
                
            }
        }
    }
}

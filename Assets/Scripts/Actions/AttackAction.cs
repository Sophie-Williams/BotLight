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
            // You can't attack plant for example,
            if (Physics.SphereCast(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, controller.eyes.forward, out hit, controller.sphereParameters.attackRange, LayerMask.GetMask("Eatable")) && hit.rigidbody.tag != "StaticEatable")
            {
                //Debug.Log("AttackAction "+controller.botAttack.botNumber);
                //if (controller.CheckIfCountDownElapsed(controller.sphereParameters.attackRate))
                //{
                    //controller.tankShooting.Fire(controller.sphereParameters.attackForce, controller.sphereParameters.attackRate);
                    // TODO : attack things
                    StateController target = hit.rigidbody.GetComponent<StateController>();
                    //Debug.Log("Target : " + target.botMovement.botNumber);
                    controller.botAttack.Attack(controller.sphereParameters.attackRate, target);
                   
                    
                    
                //}
            }
        }
    }
}

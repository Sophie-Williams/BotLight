﻿using System.Collections;
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

            if (Physics.SphereCast(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, controller.eyes.forward, out hit, controller.sphereParameters.attackRange))
            {
                if (controller.CheckIfCountDownElapsed(controller.sphereParameters.attackRate))
                {
                    //controller.tankShooting.Fire(controller.sphereParameters.attackForce, controller.sphereParameters.attackRate);
                    // TODO : attack things
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Decisions/Scan")]
    public class ScanDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool noEnemyInSight = Scan(controller);
            return noEnemyInSight;
        }

        private bool Scan(StateController controller) // TODO : try this decision
        {
            controller.botMovement.navMeshAgent.isStopped = true;
            controller.transform.Rotate(0, controller.sphereParameters.searchingTurnSpeed * Time.deltaTime, 0);
            return controller.CheckIfCountDownElapsed(controller.sphereParameters.searchDuration);
        }
    }
}
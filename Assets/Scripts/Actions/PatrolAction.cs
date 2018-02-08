using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{

    [CreateAssetMenu(menuName = "BotLight/Actions/Patrol")]
    public class PatrolAction : Action
    {

        public override void Act(StateController controller)
        {
            Patrol(controller);
        }

        private void Patrol(StateController controller)
        {
            /*
            controller.botMovement.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
            controller.botMovement.navMeshAgent.isStopped = false;

            if (controller.botMovement.navMeshAgent.remainingDistance <= controller.botMovement.navMeshAgent.stoppingDistance && !controller.botMovement.navMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            }
            */
            controller.botMovement.Move();
        }
    }
}
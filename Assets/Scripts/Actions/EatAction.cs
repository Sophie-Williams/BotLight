using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Actions/Eat")]
    public class EatAction : Action
    {


        public override void Act(StateController controller)
        {
            Eat(controller);
        }

        private void Eat(StateController controller)
        {
            controller.botMovement.navMeshAgent.destination = controller.food.position;
            // Animation
            controller.botMovement.navMeshAgent.isStopped = false; // ~= Resume() (deprecated)
        }
    }
}
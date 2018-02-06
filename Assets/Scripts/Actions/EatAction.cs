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
            controller.navMeshAgent.destination = controller.food.position;
            // Animation
            controller.navMeshAgent.isStopped = false; // ~= Resume() (deprecated)
        }
    }
}
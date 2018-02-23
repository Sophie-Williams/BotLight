using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Actions/Escape")]
    public class EscapeAction : Action
    {
        public override void Act(StateController controller)
        {
            Escape(controller);
        }

        private void Escape(StateController controller)
        {
            controller.botMovement.speed = 200; // TODO : the bot doesn't go fast ??
            controller.botMovement.MoveRandom(500);
            //controller.botMovement.Move(new Vector3(controller.transform.position.x + 100,0, controller.transform.position.z + 100));
        }
    }
}
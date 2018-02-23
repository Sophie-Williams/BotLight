using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{

    [CreateAssetMenu(menuName = "BotLight/Actions/ReachCastle")]
    public class ReachCastleAction : Action
    {

        public override void Act(StateController controller)
        {
            ReachCastle(controller);
        }

        private void ReachCastle(StateController controller)
        {
            controller.botMovement.Move(Vector3.zero);
        }
    }
}
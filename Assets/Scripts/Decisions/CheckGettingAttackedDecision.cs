using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    /// <summary>
    /// This decision is used to check if the current AI is getting attacked
    /// </summary>
    [CreateAssetMenu(menuName = "BotLight/Decisions/CheckGettingAttacked")]
    public class CheckGettingAttackedDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool attacked = GettingAttacked(controller);
            return attacked;
        }

        public bool GettingAttacked(StateController controller)
        {
            LayerMask mask = 1 << LayerMask.GetMask("Eatable", "Ground");
            Collider[] hitColliders = Physics.OverlapSphere(controller.transform.position, 10f, mask);
            //if (hitColliders.Length > 0)  Debug.Log("Getting attacked : " + hitColliders[0].name);
            return hitColliders.Length > 0; // TODO : store colliders position in controller and then use it to make the AI
            // escape in a safe direction
        }


    }
}
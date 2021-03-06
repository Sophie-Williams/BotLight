﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{
    [CreateAssetMenu(menuName = "BotLight/Decisions/LookStatic")]
    public class LookStaticDecision : Decision
    {

        public override bool Decide(StateController controller)
        {
            bool foodVisible = Look(controller);
            return foodVisible;
        }

        private bool Look(StateController controller)
        {

            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.sphereParameters.lookRange, Color.green);
 
            Collider[] hitColliders = Physics.OverlapSphere(controller.eyes.position, controller.sphereParameters.lookSphereCastRadius, LayerMask.GetMask("Eatable"));

            // search through all hit colliders for an eatable
            for (var i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].tag == "StaticEatable") // like plant
                {
                    //Debug.Log("LookForNonAnimalDecision - saw eatable");
                    if (!hitColliders[i]) continue; // exception??
                    controller.food.transform.position = hitColliders[i].transform.position; // we saw food at hit.transform position => assign to food position

                    return true; // we found an eatable. exit early
                }
            }
            
            return false; // looked through all hit colliders but none was an eatable

        }
    }
}

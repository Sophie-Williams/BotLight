using UnityEngine;
using UnityEngine.UI;

namespace BotLight
{
    public class BotAttack : MonoBehaviour
    {
        public int damage = 10;
        private bool attacked;
        private float nextAttackTime; // kind of attack speed thing, useful

        
        public void Attack(float attackRate, StateController target) // attackSpeed ?
        {
            
            // Find the BotHealth script associated with the rigidbody.
            if (target)
            {

                BotHealth targetHealth = target.GetComponent<BotHealth>();
                if (Time.time > nextAttackTime && targetHealth.isActiveAndEnabled)
                {
                    nextAttackTime = Time.time + attackRate;
                    // Set the fired flag so only Fire is only called once.
                    attacked = true;



                    if (targetHealth.getHealth() <= 0)
                        return;

                    targetHealth.TakeDamage(damage);

                }
            }

        }
    }
}
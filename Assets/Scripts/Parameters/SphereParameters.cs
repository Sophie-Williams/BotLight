using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{
    /// <summary>
    /// Used to store parameters about the sphere AI
    /// </summary>
    [CreateAssetMenu(menuName = "BotLight/AIDatas")]
    public class SphereParameters : ScriptableObject
    {
        public float moveSpeed = 1;
        public float lookRange = 40f;
        public float lookSphereCastRadius = 1f;

        public Diet diet;

        public float attackRange = 1f;
        public float attackRate = 1f;
        public float attackForce = 15f;
        public int attackDamage = 50;

        public float searchDuration = 4f;
        public float searchingTurnSpeed = 120f;
        /* ... */
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    [Serializable]
    public class SphereManager
    {

        [HideInInspector] public int sphereNumber; // May be useful ?
        [HideInInspector] public GameObject instance;         // A reference to the instance of the sphere when it is created.
        private StateController stateController;              // Reference to the StateController for AI
        private BotAttack botAttack;
        private BotHealth botHealth;
        private BotMovement botMovement;

        public void SetupAI()
        {

            // Debug.Log("Sphere number : " + sphereNumber);
            botAttack = instance.GetComponent<BotAttack>();
            botAttack.botNumber = sphereNumber;

            botMovement = instance.GetComponent<BotMovement>();
            botMovement.botNumber = sphereNumber;

            stateController = instance.GetComponent<StateController>();
            botMovement.SetupAI(stateController.SetupAI(true));



            // Get all of the renderers of the sphere. (prob useless for a sphere)
            //MeshRenderer renderer = instance.GetComponent<MeshRenderer>();

            // ... set their material color to the color specific to this tank.
            //renderer.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // Pick a random, saturated and not-too-dark color

        }
    }
}
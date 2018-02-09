using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace BotLight
{
    public class Food : MonoBehaviour
    {

        public float startingFood = 100f;               // The amount of health each tank starts with.

        // public GameObject explosionPrefab;                // A prefab that will be instantiated in Awake, then used whenever the tank dies.


        // private AudioSource explosionAudio;               // The audio source to play when the tank explodes.
        // private ParticleSystem explosionParticles;        // The particle system the will play when the tank is destroyed.
        private float currentFood;                      // How much health the tank currently has.
        private bool finished;                                // Has the tank been reduced beyond zero health yet?


        public float getCurrentFood() // can get, not set
        {
            return currentFood;
        }

        private void Awake()
        {

            // Instantiate the explosion prefab and get a reference to the particle system on it.
            // m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
            // TODO : Death animation

            // Get a reference to the audio source on the instantiated prefab.
            // m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();
            // TODO : Sound

            // Disable the prefab so it can be activated when it's required.
            // m_ExplosionParticles.gameObject.SetActive(false);
        }


        private void OnEnable()
        {
            // When the tank is enabled, reset the tank's health and whether or not it's dead.
            currentFood = startingFood;
            // Debug.Log("c Health" + currentHealth);
            // Debug.Log("s Health" + startingHealth);
            finished = false;

            // Update the health slider's value and color.
            SetFoodUI();
        }


        public void GetEaten(float amount)
        {
            Debug.Log("GetEaten : ");
            // Reduce current food by the amount of damage done.
            currentFood -= amount;
            // Change the UI elements appropriately.
            SetFoodUI();

            // If the current health is at or below zero and it has not yet been registered, call OnDeath.
            if (currentFood <= 0f && !finished)
            {
                OnFinished();
            }
        }


        private void SetFoodUI()
        {
            // Animation
        }


        private void OnFinished()
        {
            // Set the flag so that this function is only called once.
            finished = true;

            // TODO :
            // Move the instantiated explosion prefab to the tank's position and turn it on.
            // explosionParticles.transform.position = transform.position;
            // explosionParticles.gameObject.SetActive(true);

            // Play the particle system of the tank exploding.
            // explosionParticles.Play();

            // Play the tank explosion sound effect.
            // explosionAudio.Play();

            // Turn the tank off.
            //Debug.Log(GetComponentsInParent(typeof(BotMovement)));
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
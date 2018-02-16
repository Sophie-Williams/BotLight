using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace BotLight
{
    public class Food : MonoBehaviour
    {

        public float startingFood = 100f;               // The starting amount of food

        private float currentFood;                      // How much food left
        private bool finished;                                // Has the food been completely ate ?


        public float CurrentFood // can get, not set
        { get { return currentFood; } }


        private void OnEnable()
        {
            currentFood = startingFood;
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

            // If the current food is at or below zero and it has not yet been registered, call onFinished.
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

            gameObject.SetActive(false);
        }
    }
}
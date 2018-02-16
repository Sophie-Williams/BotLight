using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BotLight
{
    public class GameManager : MonoBehaviour
    {

        public int startingAnimals;    // Think to use a scriptableobject to param instead
        public GameObject[] animalPrefabs;        // prefabs
        public GameObject[] foodPrefabs;
        public GameObject groundPrefab;
        public GameObject playerPrefab;
        public Text GUI;
        [HideInInspector]
        public List<GameObject> foodInstance;
        public CameraControl cameraControl;       // Reference to the CameraControl script for control during different phases.
        [HideInInspector]
        public List<BotManager> bots;     // A collection of managers for enabling and disabling different aspects of the bots.


        private void Awake()
        {
            cameraControl.player = Instantiate(playerPrefab, new Vector3(0, 10, 0), new Quaternion(0, 0, 0, 0));

        }

        // Use this for initialization
        void Start()
        {
            
            SpawnAllAnimals();

            InvokeRepeating("SpawnFood", 5, 10);
            InvokeRepeating("DeleteFood", 62, 60);
        }

        public void SpawnAllAnimals()
        {
            for (int i = 0; i < startingAnimals; i++)
            {
                BotManager bot = new BotManager();
                bot.instance = Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], new Vector3(i * 80, 5, i * 80), new Quaternion(0, 0, 0, 0)) as GameObject;
                bot.SetupAI();
                bots.Add(bot);

            }
        }

        public void DeleteFood()
        {
            Destroy(foodInstance[0]);
            foodInstance.RemoveAt(0);
        }

        public void SpawnFood()
        {
            int whichPrefab = Random.Range(0, foodPrefabs.Length);

            Vector3 spawnPosition = new Vector3(Random.Range(0, groundPrefab.transform.localScale.x),
                Random.Range(1, groundPrefab.transform.localScale.y),
                Random.Range(0, groundPrefab.transform.localScale.z));


            foodInstance.Add(Instantiate(foodPrefabs[whichPrefab], 
                GetEmptyFoodSpace(spawnPosition, whichPrefab), 
                new Quaternion(0, 0, 0, 0)) as GameObject);
        }

        private Vector3 GetEmptyFoodSpace(Vector3 initialSpawnPosition, int whichPrefab)
        {
            foreach(GameObject GO in foodInstance){ // Food isnt deleted properly sometimes
                if (GO)
                {
                    if (GO.transform.localScale == initialSpawnPosition)
                    {
                        initialSpawnPosition.x += foodPrefabs[whichPrefab].transform.localScale.x;
                        initialSpawnPosition.y += foodPrefabs[whichPrefab].transform.localScale.y;
                        initialSpawnPosition.z += foodPrefabs[whichPrefab].transform.localScale.z;
                        return initialSpawnPosition;
                    }
                }
            }
            return initialSpawnPosition;


        }



        public IEnumerator FadeTextToFullAlpha(float t, Text i)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
            while (i.color.a < 1.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
                yield return null;
            }
        }

        public IEnumerator FadeTextToZeroAlpha(float t, Text i)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
            while (i.color.a > 0.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                yield return null;
            }
        }
    }
}
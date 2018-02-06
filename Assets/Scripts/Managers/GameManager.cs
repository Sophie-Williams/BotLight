using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BotLight
{
    public class GameManager : MonoBehaviour
    {

        public int startingAnimals;    // Think to use a scriptableobject to param instead
        public GameObject[] animalPrefabs;        // prefabs
        public CameraControl cameraControl;       // Reference to the CameraControl script for control during different phases.
        [HideInInspector]
        public List<SphereManager> spheres;     // A collection of managers for enabling and disabling different aspects of the spheres.
        public List<Transform> wayPointsForAI;

        // Use this for initialization
        void Start()
        {
            SpawnAllAnimals();
        }

        public void SpawnAllAnimals()
        {
            for (int i = 0; i < startingAnimals; i++)
            {

                SphereManager sphere = new SphereManager();
                sphere.instance = Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], new Vector3(i * 80, 50, i * 80), new Quaternion(0, 0, 0, 0)) as GameObject;
                sphere.sphereNumber = i + 1;
                sphere.SetupAI(wayPointsForAI);
                spheres.Add(sphere);

            }
        }

        private void SetCameraTargets()
        {
            // Create a collection of transforms the same size as the number of tanks.
            Transform[] targets = new Transform[spheres.Count];

            // For each of these transforms...
            for (int i = 0; i < targets.Length; i++)
            {
                // ... set it to the appropriate tank transform.
                targets[i] = spheres[i].instance.transform;
            }

            // These are the targets the camera should follow.
            cameraControl.m_Targets = targets;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
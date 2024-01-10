using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemGenerator : MonoBehaviour
{


    public GameObject sunPrefab;
    public GameObject planetPrefab;
    public GameObject moonPrefab;

    [Range(1, 10)]
    public int numberOfPlanets = 5;

    public float minOrbitRadius = 5f;
    public float maxOrbitRadius = 15f;

    [Range(0, 1)]
    public float moonChance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateSolarSystem();
    }

    void GenerateSolarSystem()
    {
        // Generate Sun
        GameObject sun = Instantiate(sunPrefab, Vector3.zero, Quaternion.identity);

        // Generate Planets
        for (int i = 0; i < numberOfPlanets; i++)
        {
            float orbitRadius = Random.Range(minOrbitRadius, maxOrbitRadius);
            float orbitSpeed = Random.Range(1f, 5f);
            GameObject planet = Instantiate(planetPrefab, new Vector3(orbitRadius, 0, 0), Quaternion.identity);

            // Set up planet motion script
            Motion planetMotion = planet.AddComponent<Motion>();
            planetMotion._speed = orbitSpeed;
            planetMotion._useSine = true;
            planetMotion._sineLength = orbitRadius;

            // Generate Moon
            if (Random.value < moonChance)
            {
                float moonOrbitRadius = Random.Range(1f, 3f);
                float moonOrbitSpeed = Random.Range(5f, 10f);
                GameObject moon = Instantiate(moonPrefab, new Vector3(moonOrbitRadius, 0, 0), Quaternion.identity);

                // Set up moon motion script
                Motion moonMotion = moon.AddComponent<Motion>();
                moonMotion._speed = moonOrbitSpeed;
                moonMotion._useSine = true;
                moonMotion._sineLength = moonOrbitRadius;

                // Attach moon to the planet
                moon.transform.parent = planet.transform;
            }
        }
    }
}


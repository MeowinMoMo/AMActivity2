using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public GameObject sunPrefab;
    public GameObject planetPrefab;
    public GameObject moonPrefab;
    public int numberOfPlanets = 5;
    public float minOrbitRadius = 5f;
    public float maxOrbitRadius = 20f;
    public float moonGenerationChance = 0.3f;

    public float planetMinSize = 0.1f;
    public float planetMaxSize = 1.9f;

    private void Start()
    {
        GameObject sun = Instantiate(sunPrefab, Vector3.zero, Quaternion.identity);

        for (int i = 0; i < numberOfPlanets; i++)
        {
            float orbitRadius = Random.Range(minOrbitRadius, maxOrbitRadius);
            float planetSize = Random.Range(planetMinSize, planetMaxSize);

            float initialAngle = Random.Range(0f, 360f);

            Vector3 initialPosition = new Vector3(
                Mathf.Cos(Mathf.Deg2Rad * initialAngle) * orbitRadius,
                0f,
                Mathf.Sin(Mathf.Deg2Rad * initialAngle) * orbitRadius
            );

            GameObject planet = Instantiate(planetPrefab, initialPosition, Quaternion.identity);
            planet.transform.localScale = new Vector3(planetSize, planetSize, planetSize);

            MotionObject planetMotionScript = planet.GetComponent<MotionObject>();
            if (planetMotionScript != null)
            {
                planetMotionScript._speed = Random.Range(1f, 5f);
                planetMotionScript._sineLength = orbitRadius;
                planetMotionScript._cosineLength = orbitRadius;
                planetMotionScript._useSine = true;
                planetMotionScript._useCosine = true;
                planetMotionScript._targetGameObject = sun;
            }

            if (Random.value < moonGenerationChance)
            {
                GenerateMoon(planet);
            }
        }
    }
    private void GenerateMoon(GameObject planet)
    {
        int numberOfMoons = Random.Range(1, 4); // Generate between 1 and 3 moons

        for (int i = 0; i < numberOfMoons; i++)
        {
            float moonOrbitRadius = Random.Range(1f, 5f);

            float initialMoonAngle = Random.Range(0f, 360f);
            Vector3 initialMoonPosition = new Vector3(
                Mathf.Cos(Mathf.Deg2Rad * initialMoonAngle) * moonOrbitRadius,
                0f,
                Mathf.Sin(Mathf.Deg2Rad * initialMoonAngle) * moonOrbitRadius
            );

            GameObject moon = Instantiate(moonPrefab, planet.transform.position + initialMoonPosition, Quaternion.identity);

            MotionObject moonMotionScript = moon.GetComponent<MotionObject>();
            if (moonMotionScript != null)
            {
                moonMotionScript._speed = Random.Range(5f, 10f);
                moonMotionScript._sineLength = moonOrbitRadius;
                moonMotionScript._cosineLength = moonOrbitRadius;
                moonMotionScript._useSine = true;
                moonMotionScript._useCosine = true;
                moonMotionScript._targetGameObject = planet;
            }
        }
    }
}


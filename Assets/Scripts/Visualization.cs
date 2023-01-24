using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Visualization : MonoBehaviour
{
    [Header("Planets")]
    public GameObject planetPrefab;
    public static List<Planet> planets = new();
    [Header("Restrictions")]
    public float lowerBoundary = -10f;
    public float upperBoundary = 10f;
    public int planetCount = 10;

    public void InstantiatePlanets()
    {
        Core.planets = Planet.CreatePlanets(planetCount, lowerBoundary, upperBoundary);
    }

    public void Initialize(GameObject planetPrefab)
    {
        this.planetPrefab = planetPrefab;
        lowerBoundary = Core.lowerBoundary;
        upperBoundary = Core.upperBoundary;
        planetCount = Core.planetCount;
    }

    public void VisualizePlanets(List<Planet> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            GameObject newPlanet = Instantiate(planetPrefab, new Vector2(planets[i].position[0], planets[i].position[1]), Quaternion.identity);
            newPlanet.name = $"Planet{planets[i].id}";
        }
    }
}
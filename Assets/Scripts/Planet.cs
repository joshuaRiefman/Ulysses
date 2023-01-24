using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet
{
    public int id;
    public float[] position = new float[2];
    public float distanceFromOrigin;
    public List<float> distances;

    public Planet(int id, float[] position)
    {
        this.id = id;
        this.position = position;
    }

    public static List<Planet> CreatePlanets(int planetCount, float lowerBoundary, float upperBoundary)
    {
        List<Planet> newPlanets = new();

        for (int i = 0; i < planetCount; i++)
        {
            float[] position = { Random.Range(lowerBoundary, upperBoundary), Random.Range(lowerBoundary, upperBoundary) };
            Planet newPlanet = new Planet(i, position);
            newPlanets.Add(newPlanet);
        }

        return newPlanets;
    }

    public static Vector2 ToVector2(float[] position)
    {
        return new Vector2(position[0], position[1]);
    }
}

[System.Serializable]
public class PlanetMap
{
    public int id;
    public float distance_from_origin;
    public List<float> distances;

    public PlanetMap(int id, float distance_from_origin, List<float> distances)
    {
        this.id = id;
        this.distance_from_origin = distance_from_origin;
        this.distances = distances;
    }
}


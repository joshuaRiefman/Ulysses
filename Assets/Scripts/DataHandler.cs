using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;

[System.Serializable]
public class DataHandler : MonoBehaviour
{
    private const string DataJSONPath = "/Users/joshuariefman/Nostradamus/Chrysanthemum/data.json";
    private const string ConstantsJSONPath = "/Users/joshuariefman/Nostradamus/Chrysanthemum/constants.json";
    private const string PathJSONPath = "/Users/joshuariefman/Nostradamus/Chrysanthemum/path.json";
    public int originPlanetID;
    public Dictionary<int, string> nameMap = new Dictionary<int, string>();

    public void InitializeData()
    {
        originPlanetID = Random.Range(0, Visualization.planets.Count);

        foreach (Planet planet in Core.planets)
        {
            planet.distanceFromOrigin = Vector2.Distance(Planet.ToVector2(planet.position), Planet.ToVector2(Core.planets[originPlanetID].position));
            planet.distances = new List<float>();

            for (int i = 0; i < Core.planets.Count; i++)
            {
                float distance = Vector2.Distance(Planet.ToVector2(planet.position), Planet.ToVector2(Core.planets[i].position));
                planet.distances.Add(distance);
            }   
        }
    }

    public void ReceiveData()
    {
        string jsonString = File.ReadAllText(ConstantsJSONPath);
        ConstantsMap constantsMap = JsonUtility.FromJson<ConstantsMap>(jsonString);
        Core.planetCount = constantsMap.universeSize;
    }

    public void UpdateData()
    {
        List<PlanetMap> maps = new List<PlanetMap>();
        foreach (Planet planet in Core.planets)
        {
            PlanetMap planetMap = new PlanetMap(planet.id, planet.distanceFromOrigin, planet.distances);
            maps.Add(planetMap);
        }

        DataMap dataMap = new DataMap(maps.ToArray(), originPlanetID);

        string jsonString = JsonUtility.ToJson(dataMap);
        File.WriteAllText(DataJSONPath, jsonString);
    }
}

[System.Serializable]
public class DataMap
{
    public PlanetMap[] Planets;
    public int starting_position;

    public DataMap(PlanetMap[] Planets, int starting_position)
    {
        this.Planets = Planets;
        this.starting_position = starting_position;
    }
}

[System.Serializable]
public class ConstantsMap
{
    public int universeSize;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [Header("Visualizations")]
    public Visualization visualization;
    [SerializeField] private GameObject planetPrefab;
    public static List<Planet> planets;
    public static float lowerBoundary = -10f;
    public static float upperBoundary = 10f;
    public static int planetCount;
    [Header("Data Handling")]
    [SerializeField] public DataHandler dataHandler;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        visualization = this.gameObject.AddComponent<Visualization>();
        dataHandler = this.gameObject.AddComponent<DataHandler>();

        dataHandler.ReceiveData();

        visualization.Initialize(planetPrefab);
        visualization.InstantiatePlanets();
        visualization.VisualizePlanets(planets);

        dataHandler.InitializeData();
        dataHandler.UpdateData();
    }
}

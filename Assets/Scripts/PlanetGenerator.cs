﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject SpherePrefab;
    public int CountPlanets;

    private void CreateOrbitPoints(LineRenderer renderer, float orbitRadius)
    {
        int points = 90;
        renderer.positionCount = points + 1;
        for (int i = 0; i <= points; i++)
        {
            float t = ((float) i / points) * Mathf.PI * 2;
            float x = orbitRadius * Mathf.Cos(t);
            float z = orbitRadius * Mathf.Sin(t);
            //if (i == points / 2 + 1)
            //{
            //    var prev = renderer.GetPosition(i - 1);
            //    prev.z = z;
            //    renderer.SetPosition(i - 1, prev);
            //}

            renderer.SetPosition(i, new Vector3(x, 0, z));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        int maxPlanets = 10;

        int countPlanets = Random.Range(0, maxPlanets + 1);

        HashSet<int> planetsIndices = new HashSet<int>();

        while (planetsIndices.Count < countPlanets)
        {
            planetsIndices.Add(Random.Range(0, maxPlanets + 1));
        }

        foreach (var planetsIndex in planetsIndices)
        {
            float RiRatio = SpaceMaths.GetPlanetRadiusByTitius_Bode(planetsIndex);
            float R = Constants.UnityUnitConverter.FromAstronomicalUnits(RiRatio);
            float T = SpaceMaths.YearsToSeconds(SpaceMaths.KeplerLawPeriod(RiRatio, 1f));
            //Debug.Log(T);
            GameObject planet = Instantiate(SpherePrefab);
            planet.name = "Planet " + (planetsIndex + 1);
            OrbitControl control = planet.GetComponent<OrbitControl>();
            CreateOrbitPoints(planet.GetComponent<LineRenderer>(), R);
            float phi_0 = Random.Range(0, Mathf.PI * 2);
            PlanetData data = new PlanetData(R, T, phi_0);
            control.SetPlanetData(data);
        }
        

        Camera.main.GetComponent<CameraSetupper>().target = GameObject.Find("Center").transform;
        //Camera.main.GetComponent<CameraSetupper>().target = GameObject.Find("Planet 3").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
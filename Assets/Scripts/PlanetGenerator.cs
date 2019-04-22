using System.Collections;
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
            float t = ((float)i / points) * Mathf.PI * 2;
            float x = Constants.AstronomicalUnitScale * orbitRadius * Mathf.Cos(t);
            float z = Constants.AstronomicalUnitScale * orbitRadius * Mathf.Sin(t);
            renderer.SetPosition(i, new Vector3(x, 0 ,z));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CountPlanets; i++)
        {
            float Ri = SpaceMaths.GetPlanetRadiusByTitius_Bode(i);
            float T = SpaceMaths.GetPeriodForPlanetFromOrbitRadius(Ri, 1f);

            GameObject planet = Instantiate(SpherePrefab);
            planet.name = "Planet " + (i + 1);
            OrbitControl control = planet.GetComponent<OrbitControl>();
            CreateOrbitPoints(planet.GetComponent<LineRenderer>(), Ri);
            float phi_0 = Random.Range(0, Mathf.PI * 2);
            control.Period = T;
            control.OrbitRadius = Ri;
            control.StartOffset = phi_0;
        }

        //Camera.main.GetComponent<CameraSetupper>().target = GameObject.Find("Center").transform;
        Camera.main.GetComponent<CameraSetupper>().target = GameObject.Find("Planet 8").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
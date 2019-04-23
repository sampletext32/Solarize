using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    public PlanetData PlanetData;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetPlanetData(PlanetData data)
    {
        PlanetData = data;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Constants.CurrentWorldRealTime % PlanetData.Period;
        float orbitOffset = t / PlanetData.Period;
        float orbitPosition = PlanetData.StartOffset + orbitOffset * Mathf.PI * 2;
        float x = PlanetData.OrbitRadius * Mathf.Cos(orbitPosition);
        float z = PlanetData.OrbitRadius * Mathf.Sin(orbitPosition);
        gameObject.transform.localPosition = new Vector3(x, 0, z);
    }
}
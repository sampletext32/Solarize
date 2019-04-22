using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    public float OrbitRadius = 1;
    public float Period = 1;
    public float StartOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float t = Constants.CurrentWorldRealTime % Period;
        float orbitOffset = t / Period;
        float orbitPosition = StartOffset + orbitOffset * Mathf.PI * 2;
        float x = Constants.AstronomicalUnitScale * OrbitRadius * Mathf.Cos(orbitPosition);
        float z = Constants.AstronomicalUnitScale * OrbitRadius * Mathf.Sin(orbitPosition);
        gameObject.transform.localPosition = new Vector3(x, 0, z);
    }
}
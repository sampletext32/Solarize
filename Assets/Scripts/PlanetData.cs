using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlanetData
{
    public float OrbitRadius { get; private set; }
    public float Period { get; private set; }
    public float StartOffset { get; private set; }

    public PlanetData(float orbitRadius, float period, float startOffset)
    {
        OrbitRadius = orbitRadius;
        Period = period;
        StartOffset = startOffset;
    }
}
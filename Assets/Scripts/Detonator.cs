using System.Collections.Generic;
using UnityEngine;

public class Detonator
{
    private float _radius = 50f;
    private float _force = 700f;

    public void Detonate(Vector3 pointOfExplosion, List<Cube> cubes)
    {
        foreach (var cube in cubes)
        {
            cube.AddExplosionForce(_force, _radius, pointOfExplosion);
        }
    }
}

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

    public void DetonateInsideArea(Vector3 pointOfExplosion, Vector3 scale)
    {
        float resultRadius = CalculateReverseProportionRelativeToSize(_radius, scale);
        float resultForce = CalculateReverseProportionRelativeToSize(_force, scale);

        Collider[] colliders = Physics.OverlapSphere(pointOfExplosion, resultRadius);
        Debug.Assert(colliders != null);

        if (colliders != null)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Cube cube))
                {
                    cube.AddExplosionForce(resultForce, resultRadius, pointOfExplosion);
                }
            }
        }
    }

    private float CalculateReverseProportionRelativeToSize(float calculatedValue, Vector3 scale)
    {
        float ratioReductionFactor = 2f;
        int baseScale = 2;
        int amountComponents = 3;
        float averageScale = (scale.x + scale.y + scale.z) / amountComponents;
        float maxPercentage = 100;

        if (averageScale == baseScale)
            return calculatedValue;

        float onePercentOfBaseScale = baseScale / maxPercentage;
        float percentageDifference = Mathf.Abs(averageScale - baseScale) / onePercentOfBaseScale;
        percentageDifference /= ratioReductionFactor;

        float onePercentOfCalculatedValue = calculatedValue / maxPercentage;
        float resultValue = 0f;

        if (averageScale > baseScale)
        {
            resultValue = calculatedValue - percentageDifference * onePercentOfCalculatedValue;
        }
        else if (averageScale < baseScale)
        {
            resultValue = calculatedValue + percentageDifference * onePercentOfCalculatedValue;
        }

        return resultValue;
    }
}

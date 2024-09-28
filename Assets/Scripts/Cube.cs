using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] Cube _prefab;

    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;
    private Detonator _detonator;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _detonator = new Detonator();
    }

    private void SetRandomColor()
    {
        float minValue = 0f;
        float maxValue = 1f;

        _meshRenderer.material.color = new Color(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), Random.Range(minValue, maxValue));
    }

    public void Init(Vector3 size)
    {
        transform.localScale = size;
        SetRandomColor();
    }

    public void Explode(List<Cube> cubes)
    {
        _detonator.Detonate(transform.position, cubes);
        Destroy(gameObject);
    }

    public void AddExplosionForce(float force, float radius, Vector3 pointOfExplosion)
    {
        _rigidbody.AddExplosionForce(force, pointOfExplosion, radius);
    }
}

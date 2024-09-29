using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;
    private int _chanceSplit = 100;

    public int ChanceSplit => _chanceSplit;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void SetRandomColor()
    {
        float minValue = 0f;
        float maxValue = 1f;

        _meshRenderer.material.color = new Color(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), Random.Range(minValue, maxValue));
    }

    public void Init(Vector3 size, int splitChance)
    {
        transform.localScale = size;
        _chanceSplit = splitChance;
        SetRandomColor();
    }

    public void AddExplosionForce(float force, float radius, Vector3 pointOfExplosion)
    {
        _rigidbody.AddExplosionForce(force, pointOfExplosion, radius);
    }
}

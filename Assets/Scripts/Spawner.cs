using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private float _divisionRatio = 2f;
    private int _minCubes = 2;
    private int _maxCubes = 6;
    float _radiusOfCreation = 6f;

    public List<Cube> Spawn(Vector3 centerSpawnPoint, Vector3 size)
    {
        int targetCubesCount = Random.Range(_minCubes, _maxCubes + 1);
        int currentCubes = 0;
        List<Cube> cubes = new List<Cube>();

        while (targetCubesCount > currentCubes)
        {
            Vector3 randomPoint = centerSpawnPoint + Random.insideUnitSphere * _radiusOfCreation;
            Cube cube = Instantiate(_prefab, randomPoint, Quaternion.identity);
            cube.Init(size / _divisionRatio);
            cubes.Add(cube);
            currentCubes++;
        }

        return cubes;
    }
}

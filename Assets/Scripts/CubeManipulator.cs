using System.Collections.Generic;
using UnityEngine;

public class CubeManipulator : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private LayerMask _layerMask;

    private MouseRaycastHandler _mouseRaycastHandler;
    private int _splitChance = 100;
    private int _amountOfChanceReduction = 20;

    private void Awake()
    {
        _mouseRaycastHandler = new MouseRaycastHandler(Camera.main, _layerMask);
    }

    private void Update()
    {
        int leftMouseButtonIndex = 0;

        if (Input.GetMouseButtonDown(leftMouseButtonIndex))
        {
            Cube cube;

            if (_mouseRaycastHandler.TryGetCube(out cube))
            {
                TryToSplit(cube);
            }
        }
    }

    private void TryToSplit(Cube cube)
    {
        if (_splitChance > 0)
        {
            int minChance = 0;
            int maxChance = 100;
            int resultChance = Random.Range(minChance, maxChance);
            List<Cube> cubes = new List<Cube>();

            if (resultChance < _splitChance)
            {
                cubes = _spawner.Spawn(cube.transform.position, cube.transform.localScale);
                cube.Explode(cubes);
                _splitChance -= _amountOfChanceReduction;
            }
            else
            {
                Destroy(cube.gameObject);
            }
        }
        else
        {
            Destroy(cube.gameObject);
        }
    }
}

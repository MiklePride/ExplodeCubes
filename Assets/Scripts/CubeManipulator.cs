using System.Collections.Generic;
using UnityEngine;

public class CubeManipulator : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private LayerMask _layerMask;

    private MouseRaycastHandler _mouseRaycastHandler;
    private Detonator _detonator;

    private void Awake()
    {
        _mouseRaycastHandler = new MouseRaycastHandler(Camera.main, _layerMask);
        _detonator = new Detonator();
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
        if (cube.ChanceSplit > 0)
        {
            int minChance = 0;
            int maxChance = 100;
            int resultChance = Random.Range(minChance, maxChance);
            List<Cube> cubes = new List<Cube>();

            if (resultChance < cube.ChanceSplit)
            {
                cubes = _spawner.Spawn(cube.transform.position, cube.transform.localScale, cube.ChanceSplit);
                _detonator.Detonate(cube.transform.position, cubes);
            }
        }

        Destroy(cube.gameObject);
    }
}

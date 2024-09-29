using UnityEngine;

public class MouseRaycastHandler
{
    private LayerMask _layerMask;
    private Camera _camera;

    public MouseRaycastHandler(Camera camera, LayerMask layerMask)
    {
        _camera = camera;
        _layerMask = layerMask;
    }

    public bool TryGetCube(out Cube cube)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float maxDistance = 100;
        cube = null;

        if (Physics.Raycast(ray, out hit, maxDistance, _layerMask))
        {
            cube = hit.collider.GetComponent<Cube>();

            return true;
        }

        return false;
    }
}

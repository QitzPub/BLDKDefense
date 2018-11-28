using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCursor
{
    Ray ray;
    RaycastHit hit;
    Vector3 rayOffset = new Vector3(0, 20, 0);
    float rayLength = 25;
    Vector3 unitOffset = new Vector3(0, 1.5f, 0);

    Vector3 position;
    bool hasFoundTile = false;

    public void inputMousePosition(Vector3 mousePosition)
    {
        hasFoundTile = false;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerUtility.GetLayerMask(LayerName.Obstacle)))
        {
            Vector3 secondPosition = hit.collider.transform.position + rayOffset;
            if (Physics.Raycast(secondPosition, Vector3.down, out hit, rayLength, LayerUtility.GetLayerMask(LayerName.Obstacle)))
            {
                position = hit.point;
                hasFoundTile = true;
            }
        }   
    }

    public bool HasFoundTile()
    {
        return hasFoundTile;
    }

    public Vector3 GetSpawnPoint(bool offset)
    {
        return offset ? position + unitOffset : position;
    }

}

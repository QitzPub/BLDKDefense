using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] List<Unit> units;

    int index = 0;

    public void UpdateIndex(int value)
    {
        index += value;
        if (index < 0)
        {
            index += units.Count;
        }
        else if (units.Count <= index)
        {
            index -= units.Count;
        }
    }

    public void SpawnUnit(Vector3 position, Quaternion rotation)
    {
        Unit unit = units[index];
        unit.Spawn(position, rotation);
    }

}

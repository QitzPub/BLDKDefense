using UnityEngine;

public class Unit : MonoBehaviour
{
    public void Spawn(Vector3 position, Quaternion rotation)
    {
        Instantiate(gameObject, position, rotation);
    }
}

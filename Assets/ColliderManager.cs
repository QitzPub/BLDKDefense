using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public List<Collider> colliders;
    public delegate void CollidersEvent();
    public CollidersEvent collidersEvent = () => {};

    void Awake()
    {
        colliders = new List<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!colliders.Any(c => c.GetInstanceID() == other.GetInstanceID()))
        {
            colliders.Add(other);
            collidersEvent();
        }
    }

    void OnTriggerExit(Collider other)
    {
        colliders = colliders
            .Where(c => c.GetInstanceID() != other.GetInstanceID())
            .ToList();
        collidersEvent();
    }
}

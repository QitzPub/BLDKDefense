using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject shape;

    void Start()
    {
        shape?.SetActive(false);
    }
}

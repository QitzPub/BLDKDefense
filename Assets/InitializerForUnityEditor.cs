using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InitializerForUnityEditor : MonoBehaviour
{
    [SerializeField] SceneType type = SceneType.Level;

    void Start()
    {
        SceneInitializer.Instance.InitializeScene(type);
    }
}

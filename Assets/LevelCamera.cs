using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    Vector3 rotation;
    Vector2 lastMousePosition;

    void Start()
    {
        rotation = Vector3.zero;
        lastMousePosition = Input.mousePosition;
    }

    public void UpdateMousePosition()
    {
        lastMousePosition = Input.mousePosition;
    }

    public void RotateCameraByMousePosition()
    {
        float x = lastMousePosition.x - Input.mousePosition.x;

        rotation.y = -x;

        transform.Rotate(rotation * rotateSpeed);
    }

    public void RotateCamera(float speed)
    {
        rotation.y = speed;
        transform.Rotate(rotation * rotateSpeed);
    }
}

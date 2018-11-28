using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInputManager : MonoBehaviour
{
    protected delegate void UpdateMousePoint();
    protected UpdateMousePoint updateMousePoint = () => { };

    protected delegate void OnPressUpArrow();
    protected OnPressUpArrow onPressUpArrow = () => { };

    protected delegate void OnPressDownArrow();
    protected OnPressDownArrow onPressDownArrow = () => { };

    protected delegate void OnPressLeftArrow();
    protected OnPressDownArrow onPressLeftArrow = () => { };

    protected delegate void OnPressRightArrow();
    protected OnPressDownArrow onPressRightArrow = () => { };

    protected delegate void OnPressSpace();
    protected OnPressSpace onPressSpace = () => { };

    protected delegate void OnPressEsc();
    protected OnPressSpace onPressEsc = () => { };

    protected delegate void OnPressDownW();
    protected OnPressSpace onPressDownW = () => { };

    protected delegate void OnPressA();
    protected OnPressSpace onPressA = () => { };

    protected delegate void OnPressDownS();
    protected OnPressSpace onPressDownS = () => { };

    protected delegate void OnPressD();
    protected OnPressSpace onPressD = () => { };

    public delegate void OnPressMouseLeftButtonDown();
    public OnPressMouseLeftButtonDown onPressMouseLeftButtonDown = () => { };

    public delegate void OnPressMouseRightButtonDown();
    public OnPressMouseRightButton onPressMouseRightButtonDown = () => { };

    public delegate void OnPressMouseRightButton();
    public OnPressMouseRightButton onPressMouseRightButton = () => { };

    public delegate void OnScrollMouseWheel(int direction);
    public OnScrollMouseWheel onScrollMouseWheel = (i) => { };

    protected void Update()
    {
        updateMousePoint();

        if (0 < Input.GetAxis("Mouse ScrollWheel"))
        {
            onScrollMouseWheel(1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            onScrollMouseWheel(-1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPressSpace();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPressEsc();
        }

        if (Input.GetMouseButtonDown(0))
        {
            onPressMouseLeftButtonDown();
        }

        if (Input.GetMouseButtonDown(1))
        {
            onPressMouseRightButtonDown();
        }

        //if (Input.GetMouseButton(1))
        //{
        //    onPressMouseRightButton();
        //}

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    onPressDownW();
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    onPressA();
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    onPressDownS();
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    onPressD();
        //}

    }


}

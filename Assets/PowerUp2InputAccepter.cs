using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2InputAccepter : InputAccepter
{
    void Start()
    {
        inputBehaviour = new PowerUp2InputBehaviour();
    }
}

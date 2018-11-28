using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInputAccepter : InputAccepter
{
    void Start()
    {
        inputBehaviour = new PowerUpInputBehaviour();
    }
}

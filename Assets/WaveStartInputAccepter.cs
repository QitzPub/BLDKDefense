using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStartInputAccepter : InputAccepter
{
    void Start()
    {
        inputBehaviour = new WaveStartInputBehaviour();
    }
}

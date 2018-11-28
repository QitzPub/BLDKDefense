using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStartInputBehaviour : InputBehaviour
{
    public override void Execute()
    {
        ObjectManager.Instance.GameStateManager.state = GameState.Wave;
        ObjectManager.Instance.WaveManager.StartWave();
    }
}

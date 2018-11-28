using UnityEngine;

public class LevelProgressManager : MonoBehaviour
{
    void Update()
    {
        if(ObjectManager.Instance.GameStateManager.state == GameState.Wave)
        {
            ProceedLevel();
        }
    }

    public void ProceedLevel()
    {
        Physics.Simulate(0.03f);
        ObjectManager.Instance.WaveManager.UpdateFrame();
    }

}

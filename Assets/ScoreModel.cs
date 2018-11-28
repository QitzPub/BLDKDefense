using UnityEngine;
using System.Collections;
using UniRx;

public class ScoreModel
{
    ReactiveProperty<int> score;
    public IReadOnlyReactiveProperty<int> Score
    {
        get { return score; }
    }

    public ScoreModel()
    {
        score = new ReactiveProperty<int>(0);
    }

    public void AddScore(int addition)
    {
        score.Value += addition;
    }
}

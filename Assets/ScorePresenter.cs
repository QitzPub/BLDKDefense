using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] ScoreView view;
    ScoreModel model;

    public void Initilize()
    {
        model = new ScoreModel();
        model.Score
            .Subscribe(view.OnScoreChanged);
    }

    public void AddScore(int addition)
    {
        model.AddScore(addition);
    }

}

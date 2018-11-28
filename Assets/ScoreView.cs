using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] Text text;

    public void OnScoreChanged(int score)
    {
        text.text = score.ToString();
    }
}

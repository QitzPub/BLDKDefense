using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] GameObject toMove;
    [SerializeField] Vector3 from;
    [SerializeField] Vector3 center;
    [SerializeField] float startDelay;
    [SerializeField] float duration;
    [SerializeField] float wait;
    [SerializeField] bool isRemains;

    void Start()
    {
        Play();
    }

    public void Play(string message = "")
    {
        if (message != "")
        {
            toMove.GetComponentsInChildren<Text>()
                      .ToList()
                      .ForEach(t => t.text = message);
        }
        toMove.transform.localPosition = from;
        toMove.transform
              .DOLocalMove(center, duration)
              .SetDelay(startDelay)
              .OnComplete(() =>
              {
                  if (!isRemains)
                  {
                      toMove.transform
                          .DOLocalMove(center - from, duration)
                          .SetDelay(wait)
                            .OnComplete(() => Destroy(gameObject));
                  }
              });
    }
}

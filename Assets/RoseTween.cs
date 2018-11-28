using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoseTween : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;
    float tweenDelay = 0.05f;
    float duration = 1;

    [SerializeField] bool isRemains;

    public void Animate()
    {
        objects.ForEach(o => o.transform.localScale = Vector3.zero);
        for (int i = 0; i < objects.Count; i++)
        {
            TweenScaleLarge(objects[i].transform, i * tweenDelay);
        }

        if (isRemains == false)
        {
            TweenScaleSmall(duration);
        }
    }

    void TweenScaleLarge(Transform target, float delay)
    {
        target.transform
              .DOScale(Vector3.one * 1.5f, 0.2f)
              .SetDelay(delay)
              .OnComplete(() => target.transform.DOScale(Vector3.one, 0.2f));
    }

    void TweenScaleSmall(float delay)
    {
        transform
              .DOScale(Vector3.zero, 0.2f)
              .SetDelay(delay)
              .OnComplete(() => Destroy(gameObject));
    }
}

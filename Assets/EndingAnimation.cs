using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UniRx;
using System;

public class EndingAnimation : MonoBehaviour
{
    [SerializeField] float startDelay;
    [SerializeField] float rosesDelay;
    [SerializeField] float textDelay;
    List<RoseTween> roses;

    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(startDelay))
            .Subscribe(_ => AnimateRose());
        Observable.Timer(TimeSpan.FromSeconds(textDelay))
            .Subscribe(_ => AnimateText());
    }

    void AnimateRose()
    {
        roses = GetComponentsInChildren<RoseTween>().ToList();
        int count = 0;

        IDisposable animation = Observable
            .Interval(TimeSpan.FromSeconds(rosesDelay))
            .Subscribe(l =>
            {
                if(count < roses.Count)
                {
                    roses[count].Animate();
                }
                count++;
            }).AddTo(this);

        Observable.Timer(TimeSpan.FromSeconds((roses.Count + 1.5) * rosesDelay))
            .Subscribe(_ =>
            {
                animation.Dispose();
            });
    }

    void AnimateText()
    {
        Instantiate(PrefabHolder.Instance.clearAnimation);
    }
}

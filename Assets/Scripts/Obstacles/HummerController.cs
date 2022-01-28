using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummerController : MonoBehaviour
{
    private const string AnimationTriggerName = "Animate";
    [Range(1, 5)]
    [SerializeField] private float _animationDelay = 1f;
    [SerializeField] private Animator _animator;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_animationDelay);
        StartCoroutine(StartDelayAnimation());
    }

    private IEnumerator StartDelayAnimation() 
    {
        for (; ; )
        {
            yield return _waitForSeconds;
            _animator.SetTrigger(AnimationTriggerName);
        }

    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}

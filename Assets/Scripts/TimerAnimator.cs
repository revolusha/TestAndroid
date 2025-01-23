using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class TimerAnimator : MonoBehaviour
{
    private const string Trigger = "trigger";
    private const float Delay= 2;

    private Animator _animator;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(WaitUntilAnimate());
    }

    private IEnumerator WaitUntilAnimate()
    {
        yield return new WaitForSeconds(Delay);

        _animator.SetTrigger(Trigger);
    }

}
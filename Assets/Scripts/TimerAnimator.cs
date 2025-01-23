using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class TimerAnimator : MonoBehaviour
{
    [SerializeField] private float _delay = 1;

    private const string Trigger = "trigger";

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
        yield return new WaitForSeconds(_delay);

        _animator.SetTrigger(Trigger);
    }

}
using System;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static Action OnHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) OnHit?.Invoke();


    }
}
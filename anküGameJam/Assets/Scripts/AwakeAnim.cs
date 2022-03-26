using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AwakeAnim : MonoBehaviour
{
    public Animator Animator;
    private void Awake()
    {
        Animator.SetBool("fadeIn",true);
    }
}

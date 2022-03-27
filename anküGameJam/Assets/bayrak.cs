using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bayrak : MonoBehaviour
{
    public Animator Animator;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Animator.SetBool("bayrak",true);

            StartCoroutine(FlagControl());
        }

    }
    IEnumerator FlagControl()
    {
        yield return new WaitForSeconds(2);
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y + 1);
    }
}

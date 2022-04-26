using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator Animator;
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    nextLevel();
        //}
    }

    public void nextLevel()
    {
        StartCoroutine(nextLevell());
    }
    IEnumerator nextLevell()
    {
        Animator.SetBool("fadeOut",true);
        yield return new WaitForSeconds(1);
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y + 1);
    }
    
}

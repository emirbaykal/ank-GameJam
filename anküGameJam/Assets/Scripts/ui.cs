using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{

    public GameObject volumeOnToggle,volumeOffToggle;
    public GameObject startCanvas;
    public GameObject optionsCanvas;
    private void Update()
    {
        if (volumeOnToggle.GetComponent<Toggle>().isOn)
        {
            volumeUp();
        }

        if (volumeOffToggle.GetComponent<Toggle>().isOn)
        {
            volumeDown();
        }
    }

    public void volumeDown()
    {
        AudioListener.volume = 0;
    }
    public void volumeUp()
    {
        AudioListener.volume = 1;
    }

    public void backButton()
    {
        optionsCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }
    public void optionsMenu()
    {
        startCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void quitButton()
    {
        Application.Quit();
    }
    
}

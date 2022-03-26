using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public void volumeDown()
    {
        AudioListener.volume = 0;
    }
    public void volumeUp()
    {
        AudioListener.volume = 1;
    }
}

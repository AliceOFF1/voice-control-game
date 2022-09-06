using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionsMenu : MonoBehaviour
{

    public GameObject Options; 

    public void Start()
    {
        Options.SetActive(false);
    }

    public void OptionsOn()
    {
        Options.SetActive(true);
    }

    public void OptionsOff()
    {
        Options.SetActive(false);
    }
}

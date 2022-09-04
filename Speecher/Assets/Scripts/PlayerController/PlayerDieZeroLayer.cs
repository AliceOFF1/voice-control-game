using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieZeroLayer : MonoBehaviour, ElementController
{

    private Animator animator;
    private bool isOpen = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivateElement()
    {
        isOpen = true;
        animator.SetBool("ZeroLayer", true);
    }

    public void DeactivateElement()
    {
        isOpen = false;
        animator.SetBool("ZeroLayer", false);

    }

    public void ToggleElement()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            ActivateElement();
        }
        else
        {
            DeactivateElement();
        }
    }

}


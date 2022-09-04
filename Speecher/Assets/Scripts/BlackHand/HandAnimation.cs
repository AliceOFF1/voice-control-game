using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour, ElementController
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
        animator.SetBool("HandActivate", true);
    }

    public void DeactivateElement()
    {
        isOpen = false;
        animator.SetBool("HandActivate", false);

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


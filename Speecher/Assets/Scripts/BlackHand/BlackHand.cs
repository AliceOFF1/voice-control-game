using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHand : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private ElementController element;
    bool Activate = false;



    private void Awake()
    {
        element = doorGameObject.GetComponent<ElementController>();
    }



    private void OnTriggerEnter2D(Collider2D collider)

    {
        if (collider.GetComponent<Player>() != null)
        //Player entered collider! 
        {
            Activate = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)

    {
        if (collider.GetComponent<Player>() != null)
        //Player entered collider! 
        {
            Activate = false;
        }

    }


    void Update()
    {
        if (Activate == true)
        {
            element.ActivateElement();
        }

        if (Activate == false)
        {
            element.DeactivateElement();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWindowAnimation : MonoBehaviour
{
    [SerializeField] private GameObject elementGameObject;
    private ElementController element;
    bool Activate = false;



    private void Awake()
    {
        element = elementGameObject.GetComponent<ElementController>();
    }



    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "DieTrigger")
        {
            Activate = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DieTrigger"))
        {
            Activate = true;
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHomeTrigger : MonoBehaviour
{
    public GameObject Light_1;
    public GameObject Light_2;
    public GameObject Light_3;

    void Start()
    {
        Light_1.SetActive(false);
        Light_2.SetActive(false);
        Light_3.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))

        {
            Light_1.SetActive(true);
            Light_2.SetActive(true);
            Light_3.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))

        {
            Light_1.SetActive(false);
            Light_2.SetActive(false);
            Light_3.SetActive(false);

        }
    }

}

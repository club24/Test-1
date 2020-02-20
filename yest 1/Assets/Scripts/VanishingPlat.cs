using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlat : MonoBehaviour
{
    //Appear refers to time before platform appears
    //Vanish refers to time after activating to vanish
    public float Appear = 3;
    public float Vanish = 1;

    Renderer Rend;
    Collider Coll;

    void OnTriggerEnter(Collider other)
    {
        Rend  = GetComponent<Renderer>();
        Coll  = GetComponent<Collider>();

        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Poof());
            StartCoroutine(Wizard());
        }
    }

    IEnumerator Poof()
    {
        yield return new WaitForSeconds(Vanish);
        Rend.enabled = false;
        Coll.enabled = false;
    }

    IEnumerator Wizard()
    {
        yield return new WaitForSeconds(Appear);
        Rend.enabled = true;
        Coll.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlat : MonoBehaviour
{
    public float Magic = 4;
    public float Seconds = 2;

    Renderer myR;
    Collider myC;

    void OnTriggerEnter(Collider other)
    {
        myR = GetComponent<Renderer>();
        myC = GetComponent<Collider>();

        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Poof());
            StartCoroutine(Wizard());
        }
    }

    IEnumerator Poof()
    {
        yield return new WaitForSeconds(Seconds);
        myR.enabled = false;
        myC.enabled = false;
        //Destroy(gameObject);
    }

    IEnumerator Wizard()
    {
        yield return new WaitForSeconds(Magic);
        myR.enabled = true;
        myC.enabled = true;
        //gameObject.SetActive(true);
    }
}

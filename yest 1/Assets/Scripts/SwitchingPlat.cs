using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingPlat : MonoBehaviour
{
    public Renderer rend;
    public Collider coll;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        coll = GetComponent<Collider>();
        coll.enabled = true;
    }

    // Toggle the Object's visibility each second.
    void Update()
    {
        // Find out whether current second is odd or even
        bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;

        // Enable renderer and collider accordingly
        rend.enabled = oddeven;
        coll.enabled = oddeven;
    }
}

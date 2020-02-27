using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script: Coin
    Author: Gareth Lockett
    Version: 1.0
    Description:    A simple script for a coin pickup. Make sure the coin object has a collider set to trigger.
                    The script spins/rotates the GameObject it is on.
                    When a GameObject, with a Rigidbody component, enters the trigger, this GameObject will be destroyed.

                    Note: We will update this script in the future to allow a 'score' to increment with each coin we pick up.
*/

public class Coin : MonoBehaviour
{
    public enum Axis { X_AXIS, Y_AXIS, Z_AXIS }

    public Axis axis;
    public float moveDistance;
    public float moveSpeed;
    public int XPValue = 1;

    void Update()
    {
        this.transform.Rotate(0f, 2f, 0f);

        Vector3 moveDirection = Vector3.zero;
        switch (this.axis)
        {
            case Axis.X_AXIS:
                moveDirection = this.transform.right;
                break;

            case Axis.Y_AXIS:
                moveDirection = this.transform.up;
                break;

            case Axis.Z_AXIS:
                moveDirection = this.transform.forward;
                break;
        }

        this.transform.position += moveDirection * Time.deltaTime * this.moveDistance * Mathf.Sin(Time.time * this.moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerControllerThatLevelsUp>().GainXP(XPValue); 


          
        }

        Destroy(this.gameObject);
    }
}

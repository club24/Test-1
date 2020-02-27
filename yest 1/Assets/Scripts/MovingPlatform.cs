using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    public enum Axis { X_AXIS, Y_AXIS, Z_AXIS }

    public Axis axis;
    public float moveDistance;
    public float moveSpeed;

    void Update()
    {
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
        other.transform.parent = this.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
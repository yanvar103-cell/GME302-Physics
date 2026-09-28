using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirmailPackage : MonoBehaviour
{
    //get a reference to the rigidbody
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //create a method that will pass in velocity/power value from launcher
    public void Init(Vector3 velocity)
    {
        //apply force to the gameObject
        _rb.AddForce(velocity, ForceMode.Impulse);
    }
}

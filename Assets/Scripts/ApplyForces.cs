using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForces : MonoBehaviour
{
    //reference to the rigidboy
    private Rigidbody _rb;
    private float _forceValue = 10f;
    private float _torqueValue = 1f;

    void Start()// Start is called before the first frame update
    {
        //Get the rigidbody component
        _rb = GetComponent<Rigidbody>();
        //AddForce to Rigidbody(with different ForceModes)
        _rb.AddRelativeForce(0, _forceValue * 0.7f, _forceValue * 0.7f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AddForce to Rigidbody(with different ForceModes)
        _rb.AddRelativeTorque(_torqueValue, 0, 0, ForceMode.Impulse);
    }
}

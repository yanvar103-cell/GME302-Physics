using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //create a reference to the gravity value
    [SerializeField] private float _gravityValue;

    void Start()// Start is called before the first frame update
    {
        //apply a different gravity value
        //Physics.gravity = new Vector3(0f, _gravityValue, 0f);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ApplyLocalGravity();
        }
    }

    void ApplyLocalGravity()
    {
        ConstantForce constantForce = GetComponent<ConstantForce>();
        constantForce.force = new Vector3(0f, _gravityValue, 0f);
    }
}

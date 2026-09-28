using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //reference to the simulatedPhysics class
    [SerializeField] private SimulatedPhysics _simulatedPhysics;
    
    //create a reference to the package prefab
    [SerializeField] private AirmailPackage _airmailPackagePrefab;

    //reference to the amount of force to apply
    [SerializeField] private float _force;

    [SerializeField] private LabComplete _labComplete;

    private void FixedUpdate()
    {
        //call the simulated trajectory function from simulatedPhysics class
        //pass in the prefab to instantiate, the position and the direction multiply by the force
        _simulatedPhysics.SimulatedTrajectory(_airmailPackagePrefab, transform.position, transform.forward * _force);
    }

    void Update()// Update is called once per frame
    {
        //get the input from player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //instantiate the packagePrefab and apply the force
            var _spawned = Instantiate(_airmailPackagePrefab, transform.position, transform.rotation);
            
            //tell package where to instantiate
            _spawned.transform.parent = transform.root;

            //call the init function from the package
            _spawned.Init(transform.forward * _force);

            _labComplete.CheckCriteria();
        }
    }
}

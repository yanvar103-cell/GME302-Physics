using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//using this namespace we get access to Unity sceneManagement classes.

public class SimulatedPhysics : MonoBehaviour
{
    //cretae a reference for the new simulated scene
    private Scene _simulatedScene;
    //create a reference to the physics scene of the simulated scene
    private PhysicsScene _physicsScene;
    //create a reference to the lab parent
    [SerializeField] private Transform _labParent;

    
    // Start is called before the first frame update
    void Start()
    {
        //set the lab parent reference
        _labParent = transform.parent.root;
        //call the new Create Simulaed Physics Scene method
        CreateSimulatedPhysicsScene();
    }

    //create a new method for creating the simulated physics scene
    void CreateSimulatedPhysicsScene()
    {
        //set the new created scene to the simulated scene reference using CreateScene method from SceneManager class
        _simulatedScene = SceneManager.CreateScene("SimulatedPhysics", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        //set the new physics scene from the simulated scene
        _physicsScene = _simulatedScene.GetPhysicsScene();

        //foreach object tagged as obstacle in labParent    
        foreach(Transform obsacle in _labParent)
        {
            if(obsacle.CompareTag("Obstacle"))
            {
                //create a reference for the simulaed obstacles and instantiate the new obstacles which has no unneccessary components
                var simulatedObstacle = Instantiate(obsacle.gameObject, obsacle.position, obsacle.rotation);
                //get the meshRenderer of each obstacle and disable it
                if(simulatedObstacle.GetComponent<Renderer>() != null)
                {
                    simulatedObstacle.GetComponent<Renderer>().enabled = false;
                }
                //move gameobjects to the new simulated physics scene
                SceneManager.MoveGameObjectToScene(simulatedObstacle, _simulatedScene);
            }
        }
    }

    //reference for the line renderer

    //create a method to simulate the trajectory
        //reference for a simulated object(airmailPackage)
        //disable renderer for simulated object
        //move this simulated object to the simulatedPhysics scene
        //apply velocity to the simulated object using Init function



}

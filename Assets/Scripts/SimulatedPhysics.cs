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
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxPhysicsIterations;

    //create a method to simulate the trajectory
    public void SimulatedTrajectory(AirmailPackage airmailPackagePrefab, Vector3 position, Vector3 velocity)
    {
        //reference for a simulated object(airmailPackage)
        var _simulatedObject = Instantiate(airmailPackagePrefab, position, Quaternion.identity);
        //disable renderer for simulated object
        _simulatedObject.GetComponent<Renderer>().enabled = false;
        //move this simulated object to the simulatedPhysics scene
        SceneManager.MoveGameObjectToScene(_simulatedObject.gameObject, _simulatedScene);
        //apply velocity to the simulated object using Init function
        _simulatedObject.Init(velocity);

        //set the amout of points in the line renderer component
        _line.positionCount = _maxPhysicsIterations;
        //in for loop, set the position of the line renderer based on a max physics iterations value
        for(int i = 0; i < _maxPhysicsIterations; i++)
        {
            //simulate the physics scene
            _physicsScene.Simulate(Time.fixedDeltaTime * 5);
            //set the positions of each point on the line renderer using the simulated object position
            _line.SetPosition(i, _simulatedObject.transform.position);
        }
        //destroy the simulated object
        Destroy(_simulatedObject.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    
    [System.Serializable]
    private struct Wheel
    {
        public WheelCollider collider;
        public Transform mesh;
    }

    [SerializeField] private Wheel[] _wheels;

    private void Update()
    {
        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].collider.GetWorldPose(out Vector3 position, out Quaternion rotation);
            _wheels[i].mesh.SetPositionAndRotation(position, rotation);
        }        
    }
}

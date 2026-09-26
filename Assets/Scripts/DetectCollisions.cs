using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _power = 10f;
    
    private void OnCollisionEnter(Collision collision)
    {
        //Detect collisions with objects tagged as Hazard
        if(collision.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("We collided with Hazard object");
            
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, _radius);
                        
            foreach (Collider collider in colliders)
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(_power, explosionPos, _radius, 3.0f, ForceMode.Impulse);
            }
        }
    }
}

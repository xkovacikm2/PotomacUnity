using UnityEngine;

public class BounceWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        var rocketBounce = other.transform.GetComponent<BounceRocket>();
        
        if (rocketBounce != null)
        {
            var contactPoint = other.contacts[0];
            var rocketRigidBody = other.transform.GetComponent<Rigidbody>();
            
            var reflection = Vector3.Reflect(rocketRigidBody.velocity, contactPoint.normal);
            rocketBounce.DoBounceRocket(reflection);
        }
    }
}

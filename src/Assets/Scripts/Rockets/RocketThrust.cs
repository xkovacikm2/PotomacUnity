using UnityEngine;

public class RocketThrust : MonoBehaviour {
    public float speed;

    private void Start() {
        Physics.IgnoreLayerCollision(9, 9);
    }

    private void Update() {
        var rigidBody = GetComponent<Rigidbody>();
        
        if (rigidBody.velocity.magnitude > 0) {
            BeforeUpdate();

            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(rigidBody.velocity.normalized), 0.2f);
        }
    }

    // Rockets ignore each other
//    private void OnCollisionEnter(Collision other) {
//        if (other.gameObject.GetComponent<RocketThrust>() != null) {
//            Physics.IgnoreCollision(other.collider, this.GetComponent<Collider>());
//        }
//    }

    protected virtual void BeforeUpdate() {
    }

    public void StartThrust() {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * speed;
    }

    public virtual void StopThrust() {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * 0f;
    }
}
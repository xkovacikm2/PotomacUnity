using UnityEngine;

public class RocketThrust : MonoBehaviour {
    public float speed;

    private void Update() {
        var rigidBody = GetComponent<Rigidbody>();

        if (rigidBody.velocity.magnitude > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(rigidBody.velocity.normalized), 0.2f);
        }
    }

    public void StartThrust() {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * speed;
    }

    public void StopThrust() {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * 0f;
    }
}
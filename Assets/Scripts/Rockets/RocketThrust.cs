using UnityEngine;

public class RocketThrust : MonoBehaviour {
    public float speed;

    private void Update() {
        BeforeUpdate();
        
        var rigidBody = GetComponent<Rigidbody>();

        if (rigidBody.velocity.magnitude > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(rigidBody.velocity.normalized), 0.2f);
        }

        AfterUpdate();
    }

    protected virtual void BeforeUpdate() {
        
    }

    protected virtual void AfterUpdate() {
        
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
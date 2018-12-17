using UnityEngine;

public class RocketThrust : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = this.transform.forward * this.speed;
        Debug.Log(rigidbody.velocity);
    }
}

using UnityEngine;

public class BoundingBoxController : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        var explode = other.transform.GetComponent<ExplodeRocket>();
        
        if (explode != null) {
            explode.Explode();
        }
    }
}

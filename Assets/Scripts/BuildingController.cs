using UnityEngine;

public class BuildingController : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        var explode = other.transform.GetComponent<ExplodeRocket>();
        
        if (explode != null) {
            explode.Explode();
            this.gameObject.SetActive(false);
        }
    }
}

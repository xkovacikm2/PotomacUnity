using UnityEngine;

public class BuildingController : MonoBehaviour {
    public bool disableParent = false;

    private void OnCollisionEnter(Collision other) {
        var explode = other.transform.GetComponent<ExplodeRocket>();

        if (explode != null) {
            explode.Explode();
            if (disableParent) {
                this.transform.parent.gameObject.SetActive(false);
            }
            else {
                this.gameObject.SetActive(false);
            }
        }
    }
}
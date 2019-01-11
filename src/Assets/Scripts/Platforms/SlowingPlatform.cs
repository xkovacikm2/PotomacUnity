using UnityEngine;

public class SlowingPlatform : MonoBehaviour {
    public float speedReduction;

    private void OnTriggerEnter(Collider other) {
        other.transform.GetComponent<FastRocketThrust>()?.SlowThrust(this.speedReduction);
    }
}

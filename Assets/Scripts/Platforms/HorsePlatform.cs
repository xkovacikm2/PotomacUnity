using UnityEngine;

public class HorsePlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        ResetTimer(other);
    }

    private void OnTriggerExit(Collider other) {
        ResetTimer(other);
    }

    private void ResetTimer(Collider other) {
        var rocket = other.GetComponent<HorseRocketThrust>();

        if (rocket != null) {
            rocket.ResetDisabledTimer();
        }
    }
}

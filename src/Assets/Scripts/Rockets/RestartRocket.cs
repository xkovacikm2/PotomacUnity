using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartRocket : MonoBehaviour {
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start() {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ResetPositionRotation() {
        transform.position = startPosition;
        transform.rotation = startRotation;
        SetActiveChildren(false);
        GetComponent<RocketThrust>().StopThrust();
    }

    public void SetActiveChildren(bool active) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(active);
        }
    }
}
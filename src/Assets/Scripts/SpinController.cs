using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour {
    public float rotationSpeed;

    void Update() {
        this.transform.Rotate(Vector3.up, this.rotationSpeed * Time.deltaTime, Space.World);
    }
}
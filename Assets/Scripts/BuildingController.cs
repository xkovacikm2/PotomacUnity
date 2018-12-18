using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        other.transform.GetComponent<ExplodeRocket>()?.Explode();
        this.gameObject.SetActive(false);
    }
}

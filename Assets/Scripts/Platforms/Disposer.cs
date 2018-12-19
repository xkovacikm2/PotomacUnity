using UnityEngine;

public class Disposer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        other.transform.GetComponent<ExplodeRocket>()?.Dispose();
    } 
}

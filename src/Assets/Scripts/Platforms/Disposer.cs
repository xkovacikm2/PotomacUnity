using UnityEngine;

public class Disposer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        other.transform.GetComponent<ExplodeRocket>()?.Dispose();
    } 
}

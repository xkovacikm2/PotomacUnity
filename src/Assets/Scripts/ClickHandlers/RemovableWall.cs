using UnityEngine;

public class RemovableWall : MonoBehaviour, IRemovable {
    public Material highlightMaterial;
    private Material originalMaterial;

    private void Start() {
        this.originalMaterial = GetComponent<MeshRenderer>().material;
    }

    public void RemoveFromScene() {
        Destroy(this.gameObject);
    }

    public void Highlight() {
        GetComponent<MeshRenderer>().material = this.highlightMaterial;
    }

    public void UnHighlight() {
        GetComponent<MeshRenderer>().material = this.originalMaterial;
    }
}

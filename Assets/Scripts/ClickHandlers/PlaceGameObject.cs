using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PlaceGameObject : MonoBehaviour {
    public Button button;
    public GameObject placedObjectPrefab;
    public Material hoverMaterial;
    public IOptionalActionable optionalAction;
    public float height;

    private LevelAuthority authority;
    private GameObject placedObjectInstance;
    private bool isTriggered;
    private Material originalMaterial;

    private void Start() {
        this.button.onClick.AddListener(OnClick);
        this.isTriggered = false;
        this.optionalAction = this.GetComponent(typeof(IOptionalActionable)) as IOptionalActionable;
        this.authority = GameObject.Find("LevelAuthority").GetComponent<LevelAuthority>();
    }

    private void Update() {
        if (!this.isTriggered) return;

        DrawObjectOnMousePosition();

        if (Input.GetKeyDown(KeyCode.Mouse0)) PlaceObject();
        if (Input.GetKeyDown(KeyCode.Mouse1)) this.optionalAction?.PerformAction(this.placedObjectInstance);
        if (Input.GetKeyDown(KeyCode.Escape)) RemoveTrigger();
    }

    private void DrawObjectOnMousePosition() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (!Physics.Raycast(ray, out hitInfo)) return;
        var position = new Vector3(Mathf.Round(hitInfo.point.x), this.height, Mathf.Round(hitInfo.point.z));
        this.placedObjectInstance.transform.position = position;
    }

    private void PlaceObject() {
        if (!this.authority.Debit(this.placedObjectInstance.GetComponent<Shoppable>().Price)) return;
        
        this.placedObjectInstance.GetComponent<MeshRenderer>().material = this.originalMaterial;
        RemoveTrigger(false);
    }

    private void RemoveTrigger(bool shouldDestroy = true) {
        if (shouldDestroy) Destroy(this.placedObjectInstance);
        this.isTriggered = false;
    }

    private void OnClick() {
        this.isTriggered = true;
        this.placedObjectInstance = Instantiate(this.placedObjectPrefab);
        this.originalMaterial = this.placedObjectInstance.GetComponent<MeshRenderer>().material;
        this.placedObjectInstance.GetComponent<MeshRenderer>().material = this.hoverMaterial;
    }
}
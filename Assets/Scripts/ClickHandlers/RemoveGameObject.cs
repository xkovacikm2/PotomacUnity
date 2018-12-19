using UnityEngine;
using UnityEngine.UI;

public class RemoveGameObject : MonoBehaviour {
    public Button button;
    private IRemovable previous;
    private LevelAuthority authority;
    private bool isTriggered;
    
    // Start is called before the first frame update
    private void Start() {
        this.isTriggered = false;
        this.button.onClick.AddListener(OnClick);
        this.previous = null;
        this.authority = GameObject.Find("LevelAuthority").GetComponent<LevelAuthority>();
    }

    // Update is called once per frame
    private void Update() {
        if (!this.isTriggered) return;
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (!Physics.Raycast(ray, out hitInfo)) return;
        var removable = hitInfo.transform.GetComponent(typeof(IRemovable)) as IRemovable;

        if (this.previous != removable) {
            this.previous?.UnHighlight();
            this.previous = removable;
            removable?.Highlight();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (removable != null) {
                removable.RemoveFromScene();
                this.authority.Credit(hitInfo.transform.GetComponent<Shoppable>().Price); 
            }

            this.previous = null;
            this.isTriggered = false;
        }
    }

    private void OnClick() {
        this.isTriggered = true;
    }
}

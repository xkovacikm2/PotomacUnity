using UnityEngine;
using UnityEngine.UI;

public class CloseWindow : MonoBehaviour {
    public Button button;
    public GameObject window;
    
    private void Start()
    {
        this.button.onClick.AddListener(OnClick);
    }

    private void OnClick() {
        this.window.SetActive(false);
    }
}

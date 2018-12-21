using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
    public Button button;

    private void Start() {
        this.button.onClick.AddListener(OnClick);
    }

    private void OnClick() {
        Application.Quit();
    }
}

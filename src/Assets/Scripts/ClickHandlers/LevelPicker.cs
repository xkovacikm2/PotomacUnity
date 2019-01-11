using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour {
    public Button button;
    public string sceneName;
    
    private void Start() {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick() {
        SceneManager.LoadScene(sceneName);
    }
}

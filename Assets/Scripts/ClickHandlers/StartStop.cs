using UnityEngine;
using UnityEngine.UI;

public class StartStop : MonoBehaviour {
    public Button button;
    private bool started;

    private void Start() {
        button.onClick.AddListener(OnClick);
        started = false;
    }

    private void OnClick() {
        if (started) {
            Stop();
        }
        else {
            Run();
        }

        started = !started;
    }

    private void Run() {
        var text = button.GetComponentInChildren<Text>();
        text.text = "Stop";

        var rockets = GameObject.FindGameObjectsWithTag("Rocket");
        foreach (var rocket in rockets) {
            rocket.GetComponent<RestartRocket>().SetActiveChildren(true);
            rocket.GetComponent<RocketThrust>().StartThrust();
        }
        
        var respawns = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (var respawn in respawns) {
            foreach (Transform child in respawn.transform) {
                child.gameObject.SetActive(true);
            }
        }
    }

    private void Stop() {
        var text = button.GetComponentInChildren<Text>();
        text.text = "Start";

        var rockets = GameObject.FindGameObjectsWithTag("Rocket");
        foreach (var rocket in rockets) {
            rocket.GetComponent<RestartRocket>().ResetPositionRotation();
        }
    }
}
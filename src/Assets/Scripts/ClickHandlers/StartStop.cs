using UnityEngine;
using UnityEngine.UI;

public class StartStop : MonoBehaviour {
    public Button button;
    private LevelAuthority authority;

    private void Start() {
        this.button.onClick.AddListener(OnClick);
        this.authority = GameObject.Find("LevelAuthority").GetComponent<LevelAuthority>();
    }

    private void OnClick() {
        if (this.authority.LevelStarted) {
            Stop();
        }
        else {
            Run();
        }

        this.authority.LevelStarted = !this.authority.LevelStarted;
    }

    private void Run() {
        var text = button.GetComponentInChildren<Text>();
        text.text = "Stop";

        var rockets = GameObject.FindGameObjectsWithTag("Rocket");
        foreach (var rocket in rockets) {
            rocket.GetComponent<RocketThrust>().StartThrust();
            rocket.GetComponent<RestartRocket>().SetActiveChildren(true);
        }
    }

    private void Stop() {
        var text = button.GetComponentInChildren<Text>();
        text.text = "Start";

        var rockets = GameObject.FindGameObjectsWithTag("Rocket");
        foreach (var rocket in rockets) {
            rocket.GetComponent<RestartRocket>().ResetPositionRotation();
            rocket.GetComponent<RestartRocket>().SetActiveChildren(true);
        }
        
        var deletables = GameObject.FindGameObjectsWithTag("DeleteOnRestart");
        foreach (var deletable in deletables) {
            Destroy(deletable);
        }
         
        var respawns = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (var respawn in respawns) {
            foreach (Transform child in respawn.transform) {
                child.gameObject.SetActive(true);
            }
        }
    }
}
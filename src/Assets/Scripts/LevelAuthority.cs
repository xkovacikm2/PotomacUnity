using UnityEngine;
using UnityEngine.UI;

public class LevelAuthority : MonoBehaviour {
    public GameObject GameOverPopup;
    public GameObject GameWonPopup;
    public int money;
    
    private bool levelStarted;
    private bool gameOver;
    private int rocketCounter;
    private int rocketCount;
    private Text moneyView;

    public bool GameOver {
        set {
            this.gameOver = value;
            this.GameOverPopup.SetActive(value);
        }
    }

    public bool LevelStarted {
        get { return this.levelStarted; }
        set {
            this.levelStarted = value;
            this.rocketCounter = this.rocketCount;
            this.GameOver = false;
        }
    }

    public void DecrementRocketCount() {
        this.rocketCounter--;
        if (this.rocketCounter == 0 && !this.gameOver) {
            this.GameWonPopup.SetActive(true);
        }
    }

    public bool Debit(int price) {
        if (this.money < price) return false;
        this.money -= price;
        this.moneyView.text = $"$ {this.money}";
        return true;
    }

    public void Credit(int price) {
        this.money += price;
        this.moneyView.text = $"$ {this.money}";
    }

    private void Start() {
        this.levelStarted = false;
        this.gameOver = false;
        this.rocketCount = GameObject.FindGameObjectsWithTag("Rocket").Length;
        this.rocketCounter = this.rocketCount;
        this.moneyView = GameObject.Find("MoneyView").GetComponent<Text>();
        this.moneyView.text = $"$ {this.money}";
    }
}

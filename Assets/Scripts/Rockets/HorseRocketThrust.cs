using UnityEngine;

public class HorseRocketThrust : RocketThrust {
    public float disabledTime;
    private float disabledTimeElapsed;

    private void Start() {
        this.disabledTimeElapsed = 0f;
    }

    protected override void BeforeUpdate() {
        if (this.disabledTimeElapsed < this.disabledTime) {
            this.disabledTimeElapsed += Time.deltaTime;
        }
        else {
            this.disabledTimeElapsed = 0f;
            var rotateTo = Random.Range(0, 10) > 5 ? this.transform.right : (this.transform.right * -1);
            this.GetComponent<Rigidbody>().velocity = rotateTo * this.speed;
        }
    }
    
    public override void StopThrust() {
        base.StopThrust();
        this.ResetDisabledTimer();
    }

    public void ResetDisabledTimer() {
        this.disabledTimeElapsed = 0f;
    }
}
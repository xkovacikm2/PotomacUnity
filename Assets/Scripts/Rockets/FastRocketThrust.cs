using UnityEngine;

public class FastRocketThrust : RocketThrust {
    public float slowedTime;
    private float originalSpeed;
    private float slowedDuration;
    private bool isSlowed;

    public bool IsSlowed => this.isSlowed;

    private void Start() {
        this.slowedDuration = 0f;
        this.originalSpeed = this.speed;
        this.isSlowed = false;
    }

    protected override void BeforeUpdate() {
        if (!this.isSlowed) return;
        
        if (this.slowedDuration < this.slowedTime) {
            this.slowedDuration += Time.deltaTime;
        }
        else {
            this.isSlowed = false;
            this.slowedDuration = 0f;
            this.speed = this.originalSpeed;
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * this.speed;
        }
    }

    public void SlowThrust(float slowFactor) {
        if (!isSlowed) {
            this.speed = this.originalSpeed * slowFactor;
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * this.speed;
            this.isSlowed = true;
        }

        this.slowedDuration = 0f;
    }

    public override void StopThrust() {
        base.StopThrust();
        
        this.speed = this.originalSpeed;
        this.isSlowed = false;
        this.slowedDuration = 0f;
    }
}

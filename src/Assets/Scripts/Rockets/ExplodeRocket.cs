using UnityEngine;

public class ExplodeRocket : MonoBehaviour {
    public GameObject explosionObject;
    public float disposalTime;
    public float disposalSpeed;
    private float disposalTimeElapsed;
    private bool isDisposed;
    private LevelAuthority authority;

    private void Start() {
        this.isDisposed = false;
        this.authority = GameObject.Find("LevelAuthority").GetComponent<LevelAuthority>();
    }

    private void Update() {
        if (!this.isDisposed) return;
        
        if (this.disposalTimeElapsed > this.disposalTime) {
            this.isDisposed = false;
            this.disposalTimeElapsed = 0;
            GetComponent<RestartRocket>().ResetPositionRotation();
            return;
        }

        this.disposalTimeElapsed += Time.deltaTime;
        this.transform.Rotate(Vector3.right, (90/this.disposalTime) * Time.deltaTime, Space.World);
        this.transform.Translate(Vector3.down * this.disposalSpeed * Time.deltaTime, Space.World);
    }

    public void Explode() {
        var explosionInstance = Instantiate(this.explosionObject);
        explosionInstance.transform.position = this.transform.position;
        this.authority.GameOver = true;
        GetComponent<RestartRocket>().ResetPositionRotation();
    }

    public void Dispose() {
        this.isDisposed = true;
        this.authority.DecrementRocketCount();
        this.GetComponent<RocketThrust>().StopThrust();
    }
}

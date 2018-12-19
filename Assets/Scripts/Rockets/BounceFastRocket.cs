using UnityEngine;

public class BounceFastRocket : BounceRocket
{
    public override void DoBounceRocket(Vector3 reflection) {
        if (this.GetComponent<FastRocketThrust>().IsSlowed) {
            base.DoBounceRocket(reflection);
        }
        else {
            this.GetComponent<ExplodeRocket>().Explode();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouceHorseRocket : BounceRocket
{
    public override void DoBounceRocket(Vector3 reflection) {
        base.DoBounceRocket(reflection);
        this.GetComponent<HorseRocketThrust>().ResetDisabledTimer();
    }
}

﻿using UnityEngine;

public class BounceRocket : MonoBehaviour
{
    public float CorrectionThreshold = 0.5f;

    public virtual void DoBounceRocket(Vector3 reflection)
    {
        var rigidBody = GetComponent<Rigidbody>();
        var correctedReflection = CorrectReflection(reflection);
        rigidBody.velocity = correctedReflection;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(correctedReflection.normalized), 0.2f);
    }

    private Vector3 CorrectReflection(Vector3 reflection)
    {
        var speed = GetComponent<RocketThrust>().speed;

        return new Vector3(CorrectReflectionValue(speed, reflection.x),
            CorrectReflectionValue(speed, reflection.y), CorrectReflectionValue(speed, reflection.z));
    }

    private float CorrectReflectionValue(float thresh, float value)
    {
        if (value < -CorrectionThreshold)
        {
            return -thresh;
        }

        if (value > CorrectionThreshold)
        {
            return thresh;
        }

        return 0f;
    }
}

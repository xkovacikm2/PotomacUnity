using UnityEngine;

public class RotateGameObject : MonoBehaviour, IOptionalActionable
{
    public void PerformAction(GameObject actionObject) {
        var oldRotation = actionObject.transform.eulerAngles;
        var rotation = new Vector3(oldRotation.x, oldRotation.y + 90, oldRotation.z);
        actionObject.transform.eulerAngles = rotation;
    }
}

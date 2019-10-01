using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float _rotationSpeed = 1f;
    
    public void RotateTowardsInputDirection(Vector2 inputDir) {

        Vector3 rotation = AngleLerp(transform.rotation.eulerAngles, GetRotation(inputDir), _rotationSpeed * Time.deltaTime);
        Quaternion quat = Quaternion.Euler(0, rotation.y, rotation.z);
        transform.rotation = quat;
    }

    public void RotateBack() {

        float yRotation = 0;
        if (transform.rotation.eulerAngles.y > 90) yRotation = 180;

        Vector3 rotation = AngleLerp(transform.rotation.eulerAngles, new Vector3(0, yRotation, 0), _rotationSpeed * Time.deltaTime);
        Quaternion quat = Quaternion.Euler(0, rotation.y, rotation.z);
        transform.rotation = quat;
    }

    Vector3 AngleLerp(Vector3 startAngle, Vector3 finishAngle, float t) {

        float xLerp = Mathf.LerpAngle(startAngle.x, finishAngle.x, t);
        float yLerp = Mathf.LerpAngle(startAngle.y, finishAngle.y, t);
        float zLerp = Mathf.LerpAngle(startAngle.z, finishAngle.z, t);
        return new Vector3(xLerp, yLerp, zLerp); ;
    }

    public Vector3 GetRotation(Vector2 inputDir) {

        Vector2 normDir = inputDir.normalized;
        float yAngle = 0f;
        float zAngle = 0f;

        if (normDir.x > 0.1f)
            yAngle = 0f;
        else if (normDir.x < -0.1f)
            yAngle = 180f;
        else
            yAngle = transform.rotation.eulerAngles.y > 90 ? 180 : 0;

        zAngle = normDir.y * 90;

        return new Vector3(0, yAngle, zAngle);
    }
}

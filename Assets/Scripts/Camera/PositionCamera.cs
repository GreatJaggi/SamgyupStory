using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCamera : MonoBehaviour
{
    //Set a fixed horizontal FOV
    public float horizontalFOV = 60f;

    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    //somewhere in update if screen is resizable

    private void Update()
    {
        cam.fieldOfView = calcVertivalFOV(horizontalFOV, Camera.main.aspect);
    }
    
    private float calcVertivalFOV(float hFOVInDeg, float aspectRatio)
    {
        float hFOVInRads = hFOVInDeg * Mathf.Deg2Rad;
        float vFOVInRads = 2 * Mathf.Atan(Mathf.Tan(hFOVInRads / 2) / aspectRatio);
        float vFOV = vFOVInRads * Mathf.Rad2Deg;
        return vFOV;
    }
}
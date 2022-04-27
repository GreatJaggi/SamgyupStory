using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Move3d : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    private float CameraYDistance;

    public int score;

    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance = 
            mainCamera.WorldToScreenPoint(transform.position).z;
        CameraYDistance =
            mainCamera.WorldToScreenPoint(transform.position).y;
    }


    void OnMouseDrag()
    {
        Vector3 ScreenPosition = 
            new Vector3(Input.mousePosition.x, CameraYDistance, CameraZDistance);

        ScreenPosition.x = Mathf.Clamp(ScreenPosition.x, 150, 930);
        
        
        Vector3 NewWorldPosition = 
            mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
    }

    
}

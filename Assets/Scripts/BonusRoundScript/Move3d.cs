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
    public ParticleSystem FoodParticle;
    public ParticleSystem GarbagePart;
    public GameObject PlayerMascotRef;

<<<<<<< HEAD
    public int Food;
    public int Garbage;
=======
>>>>>>> 242ac70189bfcd5c0bfffedc6c0271749497af59
    void Start()
    {
        FoodParticle.Stop();
        GarbagePart.Stop();
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

        ScreenPosition.x = Mathf.Clamp(ScreenPosition.x, 180, 900);
        
        
        Vector3 NewWorldPosition = 
            mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Food")
        {
<<<<<<< HEAD
            Food++;
=======
>>>>>>> 242ac70189bfcd5c0bfffedc6c0271749497af59
            FoodParticle.Play();
            PlayerMascotRef.GetComponent<Animator>().SetTrigger("Happy");
        }
        if(col.gameObject.tag == "Garbage")
        {
<<<<<<< HEAD
            Garbage++;
=======
>>>>>>> 242ac70189bfcd5c0bfffedc6c0271749497af59
            GarbagePart.Play();
            PlayerMascotRef.GetComponent<Animator>().SetTrigger("Angry");
        }
    }
<<<<<<< HEAD

    public void Success()
    {
        PlayerMascotRef.GetComponent<Animator>().SetTrigger("Wave");
    }

    public void Failed()
    {
        PlayerMascotRef.GetComponent<Animator>().SetTrigger("Sad");
    }
=======
>>>>>>> 242ac70189bfcd5c0bfffedc6c0271749497af59
}

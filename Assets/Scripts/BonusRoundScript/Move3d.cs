using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Move3d : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    private float CameraYDistance;

    private float z;
    private float y;

    public int score;
    public ParticleSystem FoodParticle;
    public ParticleSystem GarbagePart;
    public GameObject PlayerMascotRef;


    public int food;
    public int garbage;

    public GameObject DH;
    public DisplayHUD dis;

    public SoundEffectHolder SoundCon;

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


 /**   void OnMouseDrag()
    {
        
        Vector3 ScreenPosition = 
            new Vector3(Input.mousePosition.x,CameraYDistance, CameraZDistance);

        ScreenPosition.x = Mathf.Clamp(ScreenPosition.x, 150, 950);
        
        
        Vector3 NewWorldPosition = 
          mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
      
    }
**/





    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Food")
        {
            FoodParticle.Play();
            PlayerMascotRef.GetComponent<Animator>().SetTrigger("Happy");
            food++;
            SoundCon.EatSf();
            
        }
        if(col.gameObject.tag == "Garbage")
        {
            GarbagePart.Play();
            PlayerMascotRef.GetComponent<Animator>().SetTrigger("Angry");
            garbage++;
            SoundCon.MeowSf();
            
        }
    }

    public void Finish()
    {
        if (food > garbage)
        {
            PlayerMascotRef.GetComponent<Animator>().SetTrigger("Wave");
            DH.SetActive(true);
            dis.d = 5;
            SoundCon.TadaSf();
        }

        if (food < garbage)
        {
            PlayerMascotRef.GetComponent<Animator>().SetTrigger("Sad");
            DH.SetActive(true);
            dis.d = 6;
            SoundCon.LoseSf();
        }
        
        
    }


}

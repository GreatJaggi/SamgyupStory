using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{

    public int foodCount = 0;

    public static Grill instance;
    private void Awake() {
        if(Grill.instance == null)  Grill.instance = this;
        else Destroy(this.gameObject);
    }
    private void Start() {
        foodCount = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<Food>().Cook();
        //if(this.GetComponent<Collider>().bounds.Contains(other.bounds.center))
        StartCooking(other);
        foodCount++;
    }

    private void OnTriggerStay(Collider other)
    {
        //StartCooking(other);
    }

    private void StartCooking(Collider other)
    {
        other.gameObject.GetComponent<Food>().Cook();
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Food>().StopCooking();
        other.gameObject.GetComponent<Food>().isCooking = false;
        foodCount--;
    }

    public AudioSource sizzleSFX;
    private void Update() {
        // print("FOOD COUNT: " + foodCount);
        if(foodCount > 0 && !sizzleSFX.isPlaying)   {
            sizzleSFX.Play();
        }

        if(foodCount <= 0 && sizzleSFX.isPlaying)
            sizzleSFX.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<Food>().Cook();
        //if(this.GetComponent<Collider>().bounds.Contains(other.bounds.center))
        StartCooking(other);
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
    }
}

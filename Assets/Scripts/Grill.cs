using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            collision.gameObject.GetComponent<Food>().Cook();
        }
        catch (System.Exception)
        {
            Debug.Log("No component found, unable to process command. [Food.Cook()]");
            throw;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        try
        {
            collision.gameObject.GetComponent<Food>().StopCooking();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Food>().Cook();
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Food>().StopCooking();
    }
}

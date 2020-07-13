using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Material[] foodMaterials;
    
    public void Cook()
    {
        StartCoroutine("StartCooking");
    }

    public void StopCooking()
    {
        StopAllCoroutines();
        //GetComponent<Animator>().SetBool("Cooking", false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    IEnumerator StartCooking()
    {
        //GetComponent<Animator>().SetBool("Cooking", true);
        transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(5);
        ReplaceCookedFood();
        GetComponent<Rigidbody>().AddForce(Vector3.up * 1.5f, ForceMode.Impulse);

        yield return new WaitForSeconds(5);
        ReplaceOvercookedFood();
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        GetComponent<Rigidbody>().AddForce(Vector3.up * 1.5f, ForceMode.Impulse);
        yield return null;
    }

    void ReplaceCookedFood()
    {
        GetComponent<Renderer>().material = foodMaterials[0];
        
    }

    void ReplaceOvercookedFood()
    {
        GetComponent<Renderer>().material = foodMaterials[1];
    }
}

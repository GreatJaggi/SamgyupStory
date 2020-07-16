using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public float[] SPD = new float[3];

    public bool isCooking;

    public Material[] foodMaterials;

    public FoodScriptable foodObject;

    private void Awake()
    {
        foodObject.doneness = FoodScriptable.Doneness.Raw;
        isCooking = false;
    }

    public void Cook()
    {
        isCooking = true;
        StartCoroutine("StartCooking");
    }

    public void StopCooking()
    {
        StopAllCoroutines();
        //GetComponent<Animator>().SetBool("Cooking", false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Eat()
    {
        StopCooking();
        Cat.instance.AddSatisfaction(foodObject.satisfactionPoint[(int)foodObject.doneness]);
        GameObject.Find("Satisfaction Bar").GetComponent<Slider>().value = Cat.instance.GetSatisfaction();
        
        Destroy(this.gameObject);
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
        foodObject.doneness = FoodScriptable.Doneness.Done;
        GetComponent<Renderer>().material = foodMaterials[0];
    }

    void ReplaceOvercookedFood()
    {
        GetComponent<Renderer>().material = foodMaterials[1];
        foodObject.doneness = FoodScriptable.Doneness.Burnt;
    }
}

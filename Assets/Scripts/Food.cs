using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public float[] stepsPerDoneness;

    public bool isCooking;

    public Material[] foodMaterials;

    public FoodScriptable foodObject;

    public enum Doneness
    {
        Raw = 0,
        Done = 1,
        Burnt = 2
    };
    public Doneness doneness;

    private void Awake()
    {
        doneness = Doneness.Raw;
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
        Cat.instance.AddSatisfaction(foodObject.satisfactionPoint[(int)doneness]);
        GameObject.Find("Satisfaction Bar").GetComponent<Slider>().value = Cat.instance.GetSatisfaction();
        GameObject.Find("Satisfaction Bar").GetComponent<SatisfactionBar>().CheckGoal();

        //this.gameObject.SetActive(false);
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
        doneness = Doneness.Done;
        GetComponent<Renderer>().material = foodMaterials[0];
    }

    void ReplaceOvercookedFood()
    {
        GetComponent<Renderer>().material = foodMaterials[1];
        doneness = Doneness.Burnt;
    }
}

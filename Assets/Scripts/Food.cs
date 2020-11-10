using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    // public float[] stepsPerDoneness;

    public bool isCooking;
    public bool canCookOnGrillZone = false;

    public Material[] foodMaterials;

    public FoodScriptable foodObject;

    public ParticleSystem doneSparkleFX;

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
        Grill.instance.foodCount--;
        AudioController.instance.EatSFX();
        Cat.instance.AddSatisfaction(foodObject.satisfactionPoint[(int)doneness]);
        GameObject.Find("Satisfaction Bar").GetComponent<Slider>().value = Cat.instance.GetSatisfaction();
        GameObject.Find("Satisfaction Bar").GetComponent<SatisfactionBar>().CheckGoal();

        if(doneness == Doneness.Done)   {
            CatEmotions.instance.EmoteHappy();
            CatEmotions.instance.gameObject.GetComponent<Animator>().SetTrigger("Happy");
        }
            
        if(doneness == Doneness.Raw)    {
            CatEmotions.instance.EmoteSad();
            CatEmotions.instance.gameObject.GetComponent<Animator>().SetTrigger("Sad");
        }
            
        if(doneness == Doneness.Burnt)  {
            CatEmotions.instance.EmoteAngry();
            CatEmotions.instance.gameObject.GetComponent<Animator>().SetTrigger("Angry");
        }
            
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    IEnumerator StartCooking()    {
        transform.GetChild(0).gameObject.SetActive(true); // Set Cooking Smoke FX Enabled

        while(doneness != Doneness.Burnt)   {
            if(doneness == Doneness.Raw)    {
                yield return new WaitForSeconds(foodObject.cookingTimer[0]);
                GetComponent<Renderer>().material = foodMaterials[0];
                GetComponent<Rigidbody>().AddForce(Vector3.up * 1.5f, ForceMode.Impulse);
                doneness = Doneness.Done;
            }

            if(doneness == Doneness.Done)   {
                doneSparkleFX.transform.position = this.transform.position;
                doneSparkleFX.Play();
                yield return new WaitForSeconds(foodObject.cookingTimer[1]);
                GetComponent<Renderer>().material = foodMaterials[1];
                GetComponent<Rigidbody>().AddForce(Vector3.up * 1.5f, ForceMode.Impulse);
                doneness = Doneness.Burnt;
            }
        }

        // Burnt Segment
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true); // Set Burnt Smoke FX Enabled

        yield return null;
    }
/*
    IEnumerator StartCooking()
    {s
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
*/
    void ReplaceCookedFood()
    {
        doneness = Doneness.Done;
        GetComponent<Renderer>().material = foodMaterials[0];
        
    }

    void ReplaceOvercookedFood()
    {
        doneness = Doneness.Burnt;
        GetComponent<Renderer>().material = foodMaterials[1];
        doneSparkleFX.transform.position = this.transform.position;
        doneSparkleFX.Play();
    }
}

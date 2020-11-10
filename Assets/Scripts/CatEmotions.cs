using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEmotions : MonoBehaviour
{
    public Material catMaterial;
    public Texture defaultTexture;
    public  Texture happyTexture;
    public Texture sadTexture;
    public Texture angryTexture;

    public static CatEmotions instance;
    private void Awake() {
        if(CatEmotions.instance == null)
            CatEmotions.instance = this;
        else Destroy(CatEmotions.instance.gameObject);
    }

    private void Start() {
        Invoke("EmoteHappy", 1);
    }


    public void EmoteHappy()    {
        StopAllCoroutines();
        StartCoroutine("AnimateHappy");
    }

    public void EmoteSad()  {
        StopAllCoroutines();
        StartCoroutine("AnimateSad");
    }

    public void EmoteAngry()  {
        StopAllCoroutines();
        StartCoroutine("AnimateAngry");
    }

    IEnumerator AnimateHappy()    {
        catMaterial.mainTexture = happyTexture;
        yield return new WaitForSeconds(1);
        catMaterial.mainTexture = defaultTexture;
    }

    IEnumerator AnimateSad()    {
        catMaterial.mainTexture = sadTexture;
        yield return new WaitForSeconds(1);
        catMaterial.mainTexture = defaultTexture;
    }

    IEnumerator AnimateAngry()    {
        catMaterial.mainTexture = angryTexture;
        yield return new WaitForSeconds(1);
        catMaterial.mainTexture = defaultTexture;
    }
}

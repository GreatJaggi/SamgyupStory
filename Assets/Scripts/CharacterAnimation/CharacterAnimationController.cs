using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [Header("Main Material")]
    public Material mainMaterial;

    [Header("Animations")]
    // public animation sets

    public Texture[] idle;
    public Texture[] happy;
    public Texture[] sad;
    public Texture[] angry;
    public Texture[] eating;

    [Header("Main Texture")]
    public Texture defaultIdle;

    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();

        AnimateHappy();
    }

    public void AnimateIdle()   {
        StopAllCoroutines();
        // anim.SetTrigger("Happy");
        print(anim.GetCurrentAnimatorClipInfo(0).Length);
        StartCoroutine(PlayAnimation(happy, anim.GetCurrentAnimatorClipInfo(0).Length, 0.5f, true, 2));
    }

    public void AnimateHappy() {
        StopAllCoroutines();
        anim.SetTrigger("Happy");
        print(anim.GetCurrentAnimatorClipInfo(0).Length);
        StartCoroutine(PlayAnimation(happy, anim.GetCurrentAnimatorClipInfo(0).Length, 0.5f));
    }

    public void AnimateSad()   {
        StopAllCoroutines();
        anim.SetTrigger("Sad");
        print(anim.GetCurrentAnimatorClipInfo(0).Length);
        StartCoroutine(PlayAnimation(sad, anim.GetCurrentAnimatorClipInfo(0).Length, 0.5f));
    }

    public void AnimateAngry()  {
        StopAllCoroutines();
        anim.SetTrigger("Angry");
        print(anim.GetCurrentAnimatorClipInfo(0).Length);
        StartCoroutine(PlayAnimation(angry, anim.GetCurrentAnimatorClipInfo(0).Length, 0.5f));
    }

    public void AnimateEating()    {
        StopAllCoroutines();
        anim.SetTrigger("Eat");
        print(anim.GetCurrentAnimatorClipInfo(0).Length);
        StartCoroutine(PlayAnimation(eating, anim.GetCurrentAnimatorClipInfo(0).Length, 0.25f));
    }
    
    public void AnimateWaving() {
        StopAllCoroutines();
        anim.SetTrigger("Wave");
        StartCoroutine(PlayAnimation(happy, anim.GetCurrentAnimatorClipInfo(0).Length, 0.25f));
    }

    IEnumerator PlayAnimation(Texture[] textureSet,float duration, float swapInterval)  {
        float elapsedTime = 0f;
        float intervalCycle = 0f;
        int animationIndex = 0;

        while(elapsedTime < duration)    {
            elapsedTime += Time.deltaTime;
            intervalCycle += Time.deltaTime;
            // To-Do Process

            animationIndex = (int)(intervalCycle / swapInterval);
            if(animationIndex > textureSet.Length -1) {
                animationIndex = 0;
                intervalCycle = 0;
            }

            mainMaterial.mainTexture = textureSet[animationIndex];
            yield return null;
        }

        // mainMaterial.mainTexture = defaultIdle;
        StartCoroutine(PlayAnimation(idle, 1, 0.25f, true, 5));
        yield return null;
    }

    IEnumerator PlayAnimation(Texture[] textureSet,float duration, float swapInterval, bool looping, float interval)  {
        float elapsedTime = 0f;
        float intervalCycle = 0f;
        int animationIndex = 0;

        while(elapsedTime < duration)    {
            elapsedTime += Time.deltaTime;
            intervalCycle += Time.deltaTime;
            // To-Do Process

            animationIndex = (int)(intervalCycle / swapInterval);
            if(animationIndex > textureSet.Length -1) {
                animationIndex = 0;
                intervalCycle = 0;
            }

            mainMaterial.mainTexture = textureSet[animationIndex];
            yield return null;
        }

        if(looping) {
            print("Looping....");
            yield return new WaitForSeconds(interval); 
            StopAllCoroutines();
            PlayAnimation(textureSet, duration, swapInterval, looping, interval);
        }

        // mainMaterial.mainTexture = defaultIdle;
        StartCoroutine(PlayAnimation(idle, 1, 0.25f, true, 5));
        yield return null;
    }
}

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class CustomEvent : MonoBehaviour
{
    public string eventName = "Custom Event";
    public UnityEvent customEvent;
    public float delay = 0f;
    public bool onStart = false;

    private void Start() {
        if(onStart) {
            InvokeEvent();
        }
    }

    public void InvokeEvent(string eName)   {
        if(eName == eventName)
            InvokeEvent();
    }

    public void InvokeEvent()       {
        StartCoroutine("InvokeEventCoroutine", delay);
    }

    IEnumerator InvokeEventCoroutine(float timer)    {
        yield return new WaitForSeconds(timer);
        customEvent.Invoke();
        yield return null;
    }
}

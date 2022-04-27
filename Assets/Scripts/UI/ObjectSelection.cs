using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelection : MonoBehaviour
{
    public Transform objectSelectionTransform;
    public GameObject[] characterGroup;
    public Button[] buttonGroup;

    public int characterIndex = 0;

    public void SelectButton(RectTransform rt)
    {
        for (int i = 0; i < buttonGroup.Length; i++)
        {
            buttonGroup[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(buttonGroup[i].GetComponent<RectTransform>().anchoredPosition.x, 0);

            // Get Current Index
            if (buttonGroup[i].gameObject == rt.gameObject)
                characterIndex = i;
        }

        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 20);

        StopCoroutine("LerpCoroutine");
        StartCoroutine(LerpTransform(objectSelectionTransform, -1 * Vector3.right * (5 * characterIndex), 0.25f));
    }

    public void SetSelectedObject(int index)
    {
        characterIndex = index;

        objectSelectionTransform.position = -1 * Vector3.right * (5 * characterIndex);
    }

    IEnumerator LerpTransform(Transform target, Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0;

        Vector3 startPos = target.position;

        while (elapsedTime < duration)
        {
            print(target.gameObject.name + " : " + elapsedTime);
            target.position = Vector3.Lerp(startPos, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.position = targetPosition;
        yield return null;
    }

    private void Update()
    {
        // print("Character Index: " + characterIndex);
    }

    public void UnlockCharacter()
    {
        characterGroup[characterIndex].GetComponent<CharacterAnimationController>().AnimateHappy();
    }

    public void Click()
    {
        SetSelectedObject(characterIndex);
    }
}

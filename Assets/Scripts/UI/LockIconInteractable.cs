using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockIconInteractable : MonoBehaviour
{
    Button parentButton;

    private void Awake()
    {
        parentButton = this.GetComponentInParent<Button>();
    }

    private void Update()
    {
    }
}

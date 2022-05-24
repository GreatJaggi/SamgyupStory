using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float x = 10 * Time.deltaTime * 10;
        transform.Rotate(0, x, 0) ;
    }
}

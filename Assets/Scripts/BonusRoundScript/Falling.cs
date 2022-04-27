using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float speed;
    public float score;
    
    void Update()
    {
        float x = Time.deltaTime * speed;
        Vector3 vec = new Vector3(0, 1, 0) * x;
        
        transform.position -= vec;
    }


    public void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log(this.gameObject.name);
        }
        if(col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        
    }
   
    
}

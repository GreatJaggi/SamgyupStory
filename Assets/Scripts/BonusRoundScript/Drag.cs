using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private float dist;
    private float disty;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;
    private Vector3 s;
    private bool click = false;

    void Update()
    {
        Vector3 v3;

        if(Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Player")
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    disty = hit.transform.position.y - Camera.main.transform.position.y;

                    v3 = new Vector3(pos.x, disty,dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    dragging = true;
                    

                }
            }
        }
        if (dragging && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, disty,dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.x = Mathf.Clamp(v3.x, -1.75f, 1.75f);
            s = v3 + offset;
            if(click == false)
            {
                toDrag.position = v3 + offset;
                click = true;
            }
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
        }

       
        
        if(click == true)
        {
        s.x = Mathf.Clamp(s.x, -1.75f, 1.75f);
        toDrag.position = s;
            print(s);
        }
    }
}

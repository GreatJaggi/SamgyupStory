using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;
        
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    void OnMouseDrag()
    {
        //Disable Physics
        GetComponent<Rigidbody>().isKinematic = true;   
        // lock y
        transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, 0.5f, GetMouseAsWorldPoint().z + mOffset.z);
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
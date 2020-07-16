using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    
    private float yLock;

    Food food;
    private void Start()
    {
        yLock = transform.position.y + 0.5f;
        food = this.gameObject.GetComponent<Food>();
    }

    
    Touch touch;
    Transform target;
    float targetYLock = 0;
    private void Update()
    {

        
        if(Input.GetMouseButtonDown(0))
        {
            GetTarget(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            DragTarget(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleasTarget();
        }
        
        
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            // Touch Begining (OnMouseDown)
            if (touch.phase == TouchPhase.Began)
            {
                GetTarget(touch.position);
            }

            // Touch Moving (OnMouseDrag)
            if(touch.phase == TouchPhase.Moved)
            {
                DragTarget(touch.position);
            }

            // Touch Ended (OnMouseUp)
            if(touch.phase == TouchPhase.Ended)
            {
                ReleasTarget();
            }
        }
        
    }

    void GetTarget(Vector3 inputPos)
    {
        if (target != null) return;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputPos);

        if (Physics.Raycast(ray, out hit, 100.0f))
            if (hit.transform.gameObject.tag == "Food" && target == null)
            {
                targetYLock = hit.transform.localPosition.y;
                target = hit.transform;

                #region Cooking and Tapping
                if (target.GetComponent<Food>().isCooking)
                    target.GetComponent<Food>().Eat();
                #endregion
            }
    }

    void DragTarget(Vector3 inputPos)
    {
        if (target == null || target.GetComponent<Food>().isCooking) return;

        RaycastHit hit;
        target.GetComponent<Rigidbody>().isKinematic = true;
        Ray ray = Camera.main.ScreenPointToRay(inputPos);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Debug.DrawRay(hit.point, Vector3.down, Color.red);
            if (target != null)
            {
                target.transform.position = new Vector3(hit.point.x, 7.5f, hit.point.z);
            }
        }
    }

    void ReleasTarget()
    {
        if (target == null) return;
        target.GetComponent<Rigidbody>().isKinematic = false;
        target = null;
    }

    #region Handle Touch
    private Vector3 GetTouchAtWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 touchPoint = touch.position;

        // z coordinate of game object on screen
        touchPoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(touchPoint);
    }

    void OnTouchDown(Transform target)
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; // yLock
        //mZCoord = gameObject.transform.position.z; // Screen Space

        // Store offset = gameobject world pos - mouse world pos
        mOffset = target.gameObject.transform.position - GetTouchAtWorldPoint();
        #region Cooking and Tapping
        if (food.isCooking)
            food.Eat();
        #endregion
    }

    void OnTouchDrag(Transform target)
    {
        if (food.isCooking)
            return; // if cooking cannot be dragged, return

        GetComponent<Rigidbody>().isKinematic = true; // Disables physics

        // tranform and lock on y axis
        //target.transform.position = new Vector3(GetTouchAtWorldPoint().x + mOffset.x, yLock, GetTouchAtWorldPoint().z + mOffset.z * 10); // + ZOffset
        target.transform.position = new Vector3(GetTouchAtWorldPoint().x + mOffset.x, yLock, GetTouchAtWorldPoint().z);
    }

    void OnTouchEnded()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    
    #endregion

    /*
    #region Handle Mouse
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; // yLock
        //mZCoord = gameObject.transform.position.z; // Screen Space

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        #region Cooking and Tapping
        if (food.isCooking)
            food.Eat();
        #endregion
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
        if (food.isCooking)
            return; // if cooking cannot be dragged, return

        GetComponent<Rigidbody>().isKinematic = true; // Disables physics

        

        // tranform and lock on y axis
        //transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, yLock, GetMouseAsWorldPoint().z + mOffset.z * 10); // + ZOffset
        transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, yLock, GetMouseAsWorldPoint().z);// GetMouseAsWorldPoint().y);
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    #endregion
    */
}
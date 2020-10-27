using UnityEngine;

public class DragObject : MonoBehaviour
{
    Touch touch;

    Transform target;
    float targetYLock = 0;
    Transform targetParent;

    private void Update()
    {
        #region Handle Mouse
        if (Input.GetMouseButtonDown(0))
            GetTarget(Input.mousePosition);

        if (Input.GetMouseButton(0))
            DragTarget(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
            ReleaseTarget();
        #endregion

        #region Handle Touch
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                GetTarget(touch.position);
            
            if (touch.phase == TouchPhase.Moved)
                DragTarget(touch.position);
            
            if (touch.phase == TouchPhase.Ended)
                ReleaseTarget();
        }
        #endregion
    }

    void GetTarget(Vector3 inputPos)
    {
        if (target != null) return;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputPos);

        if (Physics.Raycast(ray, out hit, 100.0f))
            if (hit.transform.gameObject.tag == "Food" && target == null)
            {
                targetYLock = hit.transform.localPosition.y + 1;
                target = hit.transform;

                //targetParent = target.parent;
                //target.parent = null;

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
            Debug.DrawRay(hit.point, Vector3.down * 5f, Color.red);
            if (target != null)
            {
                target.transform.position = new Vector3(hit.point.x, -1.75f, hit.point.z);
            }
        }
    }

    void ReleaseTarget()
    {
        if (target == null) return;
        target.GetComponent<Rigidbody>().isKinematic = false;
        //target.parent = targetParent;
        target = null;
    }

    #region Debug GUI
    void xOnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h);
        style.alignment = TextAnchor.LowerLeft;
        style.fontSize = h * 2 / 100;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = new Color(0f, 0f, 0f, 1.0f);

        float x = 0;
        float y = 0;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            x = hit.point.x;
            y = hit.point.z;
        }
        string text = string.Format("X: {0} | Y : {1}", x, y);
        GUI.Label(rect, text, style);
    }
    #endregion
}
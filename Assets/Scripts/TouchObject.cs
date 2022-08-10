using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private float pressTime = 0;

    void Update()
    {
        moveAfterLongTouch();
    }

    void moveAfterLongTouch()
    {

        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);

        switch (touch.phase)
        {
           
            case TouchPhase.Began:
                Debug.Log("Başladı");
                pressTime = 0;
                break;

            case TouchPhase.Stationary:
                Debug.Log("Stat");
                pressTime += Time.deltaTime;
                break;

            case TouchPhase.Ended:
                Debug.Log("Ended " + pressTime);
                if (pressTime > 0.8f)
                {
                    recycleTouchedObject();
                }
                pressTime = 0;
                break;
            case TouchPhase.Canceled:
                Debug.Log("Cancelled " + pressTime);
                if (pressTime > 0.8f)
                {
                    recycleTouchedObject();
                }
                pressTime = 0;
                break;
        }
    }

    void recycleTouchedObject()
    {
        //If object touched for touchLimit seconds, move object
        var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            var rig = hitInfo.collider.GetComponent<Rigidbody>();
            if (rig != null)
            {
                hitInfo.transform.Translate(100f, 0, 0);

            }
        }
    }
}
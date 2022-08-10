using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private float pressTime = 0;
    [SerializeField] GameObject laser;
    private Camera cam;

    private void Start()
    {
        laser = GameObject.FindGameObjectWithTag("Laser");
        cam = Camera.main;
    }

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
                pressTime = 0;
                // Look to touch position yapmak istiyorum ama touch 3d olmadığı için yapamıyorum. Ne yapabilirim?
                // Vector3 temp = new Vector3(touch.position.x, touch.position.y, 0);

                //var ray = cam.ScreenToWorldPoint(touch.position);
              //  Debug.Log("ray is: " + ray);
                /*
                Vector3 direction = ray - laser.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                laser.transform.rotation = Quaternion.Lerp(laser.transform.rotation, rotation, 5f * Time.deltaTime);
                */
              //  laser.transform.LookAt(ray);

                break;

            case TouchPhase.Stationary:
                pressTime += Time.deltaTime;
                var ray = cam.ScreenToWorldPoint(touch.position);
                Debug.Log("ray is: " + ray);
                laser.transform.LookAt(ray);
                break;

            case TouchPhase.Ended:

            case TouchPhase.Canceled:
                if (pressTime > 0.5f)
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
                float randomX = Random.Range(10f, 30f);
                Debug.Log(randomX);
                hitInfo.transform.Translate(randomX, 0, 0);

            }
        }
    }

   
}
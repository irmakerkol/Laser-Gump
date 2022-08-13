using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private float pressTime = 0;

    private int countDestroyedObject = 0;
    [SerializeField] private AudioClip woodDestClip, levelClip;

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
                break;

            case TouchPhase.Stationary:
                pressTime += Time.deltaTime;
                break;

            case TouchPhase.Ended:

            case TouchPhase.Canceled:
                if (pressTime > 0.3f)
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
                if(LevelManager.instance.level == 0 && countDestroyedObject != 15){
                    int randomX = Random.Range(10, 20);
                    countDestroyedObject++;
                    hitInfo.transform.Translate(randomX, 0, 0);
                    AudioManager.instance.playSound(woodDestClip);
                } else if(countDestroyedObject == 15){
                    int randomX = Random.Range(10, 20);
                    LevelManager.instance.levelUp();
                    AudioManager.instance.playSound(levelClip);
                    countDestroyedObject ++;
                    LevelManager.instance.level = 1;
                } else if(LevelManager.instance.level == 1){
                    int randomX = Random.Range(5, 15);
                    hitInfo.transform.Translate(randomX, 0, 0);
                    AudioManager.instance.playSound(woodDestClip);
                }
             
            }
        }
    }

   
}
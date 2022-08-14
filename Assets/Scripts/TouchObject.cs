using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private float pressTime = 0;

    private int countDestroyedObject = 0;
    [SerializeField] private AudioClip woodDestClip, levelClip;


    void Start(){

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
            var name = hitInfo.collider.name;
            if (rig != null)
            {
                if(LevelManager.instance.level == 0 && countDestroyedObject != 15){
                    int randomZ = Random.Range(10, 20);
                    countDestroyedObject++;
                    if(name != "informer"){
                        hitInfo.transform.Translate(0, 0, -randomZ);
                    }
                    AudioManager.instance.playSound(woodDestClip);
                } else if(countDestroyedObject == 15){
                    LevelManager.instance.levelUp();
                    AudioManager.instance.playSound(levelClip);
                    countDestroyedObject ++;
                    LevelManager.instance.level = 1;
                } else if(LevelManager.instance.level == 1){
                    int randomY = Random.Range(5, 15);
                    if (name != "informer")
                    {
                        hitInfo.transform.Translate(0, randomY, 0);
                    }
                    AudioManager.instance.playSound(woodDestClip);
                }
             
            }
        }
    }

   
}
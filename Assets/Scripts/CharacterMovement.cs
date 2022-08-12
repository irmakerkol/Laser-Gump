using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = InputWrapper.Input;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] GameObject road;
    [SerializeField] GameObject road2;

    // Update is called once per frame
    void Update()
    {
    
        if (Input.touchCount > 0 && !GameManager.instance.gameStarted)
        {
            GameManager.instance.startGame();
        }
        if (GameManager.instance.gameStarted)
        {
            this.transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);
        }

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            GameManager.instance.endGame();
            SceneManager.LoadSceneAsync("SampleScene");
        }
        if (coll.gameObject.tag == "Informer1")
        {
            road.transform.position = new Vector3(road.transform.position.x + 400, road.transform.position.y, road.transform.position.z);
        }

        if (coll.gameObject.tag == "Informer2")
        {
            road2.transform.position = new Vector3(road2.transform.position.x + 400, road2.transform.position.y, road2.transform.position.z);
        }
    }
}

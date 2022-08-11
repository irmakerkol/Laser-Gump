using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = InputWrapper.Input;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;

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
    }

}

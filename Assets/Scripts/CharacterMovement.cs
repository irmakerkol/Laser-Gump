using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = InputWrapper.Input;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    GameManager gm = new GameManager();

    // Update is called once per frame
    void Update()
    {
     
        if (Input.touchCount > 0 && !gm.gameStarted)
        {
            gm.gameStarted = true;
        }
        if (gm.gameStarted)
        {
            this.transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);

        }

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            Debug.Log("Öldün");
            gm.gameStarted = false;
            SceneManager.LoadSceneAsync("SampleScene");

        }
    }

}

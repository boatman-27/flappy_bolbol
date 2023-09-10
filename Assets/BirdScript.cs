using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdisAlive = true;

    public bool paused = false;



    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdisAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (myRigidbody.transform.position.y < -14 || myRigidbody.transform.position.y > 14)
        {
            logic.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && birdisAlive)
        {
            PauseGame();
            paused = true;
        }

        if (paused == true && Input.GetKeyDown(KeyCode.C))
        {
            ResumeGame();
            paused = false;
        }

    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdisAlive = false;
    }
}

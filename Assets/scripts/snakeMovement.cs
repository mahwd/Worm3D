using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class snakeMovement : MonoBehaviour {

    [SerializeField]
    private AudioClip gameMusic;
    [SerializeField]
    private AudioClip stunned;
    public AudioSource musicSource;
    [HideInInspector]
    public static bool isAlive;
    public float speed;
    private float forsaj=2;
    private float RotationSpeed;
    private float speedBck;

    [HideInInspector]
    public List<GameObject> snakeBody = new List<GameObject>();
    [SerializeField]
    private GameObject snakeBodyPrefab;

    [HideInInspector]
    public float score = 0;
    public Text scoreText;
    public Text highScore;

    private float timeToEat { get; set; }
    private float timePlayed;

    void Start () {
        musicSource.clip = gameMusic;
        isAlive = true;
        snakeBody.Add(gameObject);
        RotationSpeed = speed * 120;
        forsaj *= speed;
        speedBck = speed;
        musicSource.Play();
        musicSource.loop = true;
    }
	
    public void turnRight()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
    }

    public void turnLeft()
    {
        transform.Rotate(Vector3.down * RotationSpeed * Time.deltaTime);
    }

    public void jump()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y+.1f,transform.position.z);
    }
    public void speedUp()
    {
        speed = forsaj;
        RotationSpeed /= forsaj;
    }
    public void speedDown()
    {
        speed = speedBck;
        RotationSpeed = speedBck * 120;
    }

    void Update() {

        // calculation of time for eating the apple/////////////////////////////////////

        timeToEat += Time.deltaTime;
        timePlayed += Time.deltaTime;
        speed += timePlayed/50; 
        ////////////////////////////////////////////////////////////////////////////////

        //  manipulation inputs/////////////////////////////////////
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            turnRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            turnLeft();
        }
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftAlt))
        {
            speedUp();
        }
        else
        {
            speedDown();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jump();
        }
        scoreText.text = score.ToString();
        if (score<PlayerPrefs.GetFloat("HighScore"))
        {
            highScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
        }
        else
        {
            highScore.text = score.ToString();
        }

        ///////////////////////////////////////////////////////////

        //  pause game//////////////
        if (Input.GetKeyDown(KeyCode.Escape) && level1.isPaused)
        {
            level1.ResumeGame();
            level1.isPaused = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !level1.isPaused)
        {
            level1.PauseGame();
            level1.isPaused = true;
        }
        //////////////////////////

        ///////   GameOver process //////////////////////////////////
        if (!isAlive)
        {
            musicSource.Stop();
            GameOver.OnGameOver(this);
        }
        ////////////////////////////////////////////////////////////

        //////////  Touch inputs   /////////////////////////////////
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                turnLeft();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                turnRight();
            }
        }
        else if (Input.touchCount == 2)
        {
            speedUp();
        }
        //////////////////////////////////////////////////////////////
    }

    public void AddTail()
    {
        score += timePlayed/timeToEat;
        timeToEat = 0;
        Vector3 newtailPos = snakeBody[snakeBody.Count-1].transform.position;
        snakeBody.Add((GameObject)Instantiate(snakeBodyPrefab,newtailPos,transform.rotation));
    }

}

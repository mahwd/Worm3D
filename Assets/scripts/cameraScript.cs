using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    public Camera cam;
    public snakeMovement snake;
    void Start () {
	    	
	}
	
	void Update () {
        if (snake.transform.position.x<Screen.width/2 && snake.transform.position.z>Screen.height/2)
        {
            Camera.main.transform.rotation = Quaternion.Euler(93,-40,-40);
        }
	}
}

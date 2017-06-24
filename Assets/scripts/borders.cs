using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class borders : MonoBehaviour {

	
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snakeHead"))
        {
            snakeMovement.isAlive = false;
        }    
    }
}

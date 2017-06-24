using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snakeHead"))
        {
            other.GetComponent<snakeMovement>().AddTail();
            Destroy(gameObject);
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

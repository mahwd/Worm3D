using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailMovement : MonoBehaviour {

    public float speed;
    public Vector3 tailTarget;
    public GameObject tailTargetObj;
    public snakeMovement snakeHead;
    private int index;

    void Start () {
        snakeHead = GameObject.FindGameObjectWithTag("snakeHead").GetComponent<snakeMovement>();
        speed = snakeHead.speed * 4f* Time.deltaTime*80;
        tailTargetObj = snakeHead.snakeBody[snakeHead.snakeBody.Count-2];
        index = snakeHead.snakeBody.IndexOf(gameObject);
    }
	
	void Update () {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position,tailTarget,Time.deltaTime*speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snakeHead") && index>33)
        {
            snakeMovement.isAlive = false;
        }
    }
}

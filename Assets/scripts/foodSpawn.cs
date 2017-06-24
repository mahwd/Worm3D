using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawn : MonoBehaviour {


    public float Zsize = 4f;
    public float Xsize = 7.7f;

    public GameObject foodPrefab;
    GameObject currentFood;





    void SpawnFood () {
        currentFood = (GameObject)Instantiate(foodPrefab, RandomPos(Xsize, Zsize), Quaternion.identity);
    }
	
	void Update () {
        if (!currentFood)
        {
            SpawnFood();
        }
	}
//  Random Position generator for food=========================================================================
    Vector3 RandomPos(float x, float z)
    {
        return new Vector3(Random.Range(-x, x), .15f, Random.Range(-z, z));
    }

    //=========================================================================================================
}

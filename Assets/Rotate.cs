using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	// Use this for initialization

	
    void Update()
    {
        // ...also rotate around the World's Y axis
        transform.Rotate(Vector3.up * Time.deltaTime * 2, Space.World);
    }
}
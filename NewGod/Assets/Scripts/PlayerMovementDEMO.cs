using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDEMO : MonoBehaviour {
    private Rigidbody rig;
    private float speed = 20f;
    private float RotationSpeed = 100f;
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float lr = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 diffPos = new Vector3(lr, 0, translation);

        transform.Translate(diffPos);
        //transform.Rotate(Vector3.up, lr);
    }
}

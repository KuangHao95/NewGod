using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDEMO : MonoBehaviour {
    private float speed = 10f;
	
	// Update is called once per frame
	void FixedUpdate () {
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

		transform.position += vertical * transform.forward + horizontal * transform.right;
    }
}

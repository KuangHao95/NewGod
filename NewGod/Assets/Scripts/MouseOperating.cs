using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class MouseOperating : MonoBehaviour {
    RaycastHit hit;
    Ray ray;
    GameObject root;
    GameObject player;
    GameObject hitPivot;
    GameObject hitObj;
    GameObject hitCam;
    Vector3 diffPos;

    // Use this for initialization
    void Awake () {
        root = GameObject.Find("GameStuff");
        player = root.transform.Find("Sphere").gameObject;
        diffPos = new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) && player.activeSelf == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //print("hit:" + hit.collider.gameObject.name);
                hitObj = hit.collider.gameObject;
                if (hitObj.tag != "target") return;
                hitPivot = hitObj.transform.Find("pivot").gameObject;
                hitPivot.transform.Rotate(0, 0, 0);
                hitCam = hitObj.transform.Find("pivot/Camera").gameObject;
                hitCam.SetActive(true);
                hitCam.tag = "MainCamera";
                player.SetActive(false);
                hitObj.GetComponent<PlayerMovementDEMO>().enabled = true;
                hitObj.GetComponent<FreeLookCam>().enabled = true;
                hitObj.GetComponent<MouseOperating>().enabled = true;
                //hitObj.AddComponent<PlayerMovementDEMO>();
                //hitObj.AddComponent<FreeLookCam>();
                //hitObj.AddComponent<MouseOperating>();
            }
        }
        else if (Input.GetMouseButtonDown(0) && player.activeSelf == false)
        {
            player.SetActive(true);
            player.transform.position = transform.position + diffPos;
            gameObject.transform.Find("pivot/Camera").gameObject.SetActive(false);
            gameObject.GetComponent<PlayerMovementDEMO>().enabled = false;
            gameObject.GetComponent<FreeLookCam>().enabled = false;
            gameObject.GetComponent<MouseOperating>().enabled = false;
            //Destroy(gameObject.GetComponent<PlayerMovementDEMO>());
            //Destroy(gameObject.GetComponent<FreeLookCam>());
            //Destroy(gameObject.GetComponent<MouseOperating>());
        }
	}
}

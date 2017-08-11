using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay (transform.position, transform.forward);

        if (Input.GetMouseButtonDown (0)) {
            Debug.Log ("Clicked");

            RaycastHit hit = new RaycastHit ();
            if (Physics.Raycast (transform.position, transform.forward, out hit)) {
                Debug.Log ("Hit " + hit.collider.gameObject.name);

            }
        }
	}
}

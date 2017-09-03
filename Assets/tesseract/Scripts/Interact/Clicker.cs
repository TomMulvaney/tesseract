using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay (transform.position, transform.forward);

        if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
            
            RaycastHit hit = new RaycastHit ();
            if (Physics.Raycast (transform.position, transform.forward, out hit)) {
                
                IClickable clickable = hit.collider.GetComponent (typeof(IClickable)) as IClickable;
                if (clickable != null) {
                    clickable.Click (this);
                }
            }
        }
	}
}

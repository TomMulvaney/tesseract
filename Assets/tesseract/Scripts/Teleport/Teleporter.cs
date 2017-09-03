using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Transform moveTarget;
    public List<Collider> clickTargets = new List<Collider> ();
    public TeleportTransition transition;
    List<GameObject> enableObjs = new List<GameObject>();

	// Use this for initialization
	void Awake () {
        foreach (Collider target in clickTargets) {
            Clickable clickable = target.gameObject.AddComponent <Clickable> ();
        }
	}

    void OnClickTarget (IClickable clickable) {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Transform moveTarget;
    public List<Collider> clickTargets = new List<Collider> ();
    public TeleportTransition transition;

	// Use this for initialization
	void Awake () {
        foreach (Collider target in clickTargets) {
            Clickable clickable = target.gameObject.AddComponent <Clickable> ();
            clickable.OnClick += OnClickTarget;
        }
	}

    void OnClickTarget (IClicker clicker, IClickable clickable) {
        ITeleportable teleportable = clicker.GetGameObject ().GetComponent (typeof(ITeleportable)) as ITeleportable;

        if (teleportable == null) {
            teleportable = clicker.GetGameObject ().GetComponentInParent (typeof(ITeleportable)) as ITeleportable;
        }

        if (teleportable != null) {
            teleportable.Teleport (moveTarget, transition);
        } else {
            Debug.LogWarning(string.Format ("IClicker {0} clicked on Teleporter but has no ITeleportable", clicker.GetGameObject ().name));
        }
	}

    public void SetMoveTarget(Transform newMoveTarget) {
        moveTarget = newMoveTarget;
    }

    public void AddClickTarget(Collider newCLickTarget) {
        clickTargets.Add (newCLickTarget);
    }
}

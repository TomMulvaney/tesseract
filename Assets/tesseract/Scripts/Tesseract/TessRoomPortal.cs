using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessRoomPortal : MonoBehaviour {

    Renderer renderer;
    Teleporter teleporter;

    void Awake() {
        Collider collider = gameObject.GetComponent <Collider> ();

        teleporter = gameObject.AddComponent <Teleporter> ();

        teleporter.AddClickTarget (collider);

        renderer = gameObject.GetComponent <Renderer> ();
    }

    public void SetMoveTarget(Transform newMoveTarget) {
        teleporter.SetMoveTarget (newMoveTarget);
    }

    public void SetColor(Color newColor) {
        renderer.material.color = newColor;
    }
}

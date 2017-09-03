using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessNetCube : TessCube {

    Collider collider;

    protected virtual void Awake() {
        Collider coll = GetComponent<Collider>();
        if (coll != null) {
            Clickable clickable = coll.gameObject.AddComponent <Clickable>();
            if (clickable != null) {
                clickable.OnClick += Click;
                collider = coll;
            } else {
                Debug.LogError ("TessCube failed to add Clickable component to collider");
            }
        }

        if (collider == null) {
            Debug.LogWarning ("TessCube has no colliders");
        }
    }

    public override void Enable(bool enabled) {
        collider.enabled = enabled;

        base.Enable (enabled);
    }
}

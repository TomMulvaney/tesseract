﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessNetCube : TessCube {

    Collider coll;

    protected override void Awake() {
        base.Awake ();

        coll = gameObject.GetComponent <Collider>();
        if (coll == null) {
            Debug.LogWarning ("TessCube has no Collider");
        }
    }

    public override void SetVisible (bool isVisible) {
        base.SetVisible (isVisible);

        if (coll != null) {
            coll.enabled = isVisible;
        }
    }
}

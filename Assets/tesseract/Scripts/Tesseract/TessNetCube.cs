using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessNetCube : TessCube, IClickable {

    Renderer render;
    MeshRenderer meshRender;
    Collider coll;

    void Awake() {

        render = gameObject.GetComponent <Renderer>();
        if (render == null) {
            Debug.LogWarning ("TessCube has no Renderer");

        }

        meshRender = gameObject.GetComponent <MeshRenderer>();
        if (meshRender == null) {
            Debug.LogWarning ("TessCube has no MeshRenderer");

        }

        coll = gameObject.GetComponent <Collider>();
        if (coll == null) {
            Debug.LogWarning ("TessCube has no Collider");

        }
    }

    public override void SetColor(Color newColor) {
        if (render != null) {
            render.material.color = newColor;
        }
    }

    public override void Click() {
        base.Click ();
    }

    public override void SetVisible (bool isVisible) {
        if (meshRender != null) {
            meshRender.enabled = isVisible;
        }

        if (coll != null) {
            coll.enabled = isVisible;
        }
    }
}

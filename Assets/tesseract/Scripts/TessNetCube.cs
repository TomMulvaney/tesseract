using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessNetCube : TessCube {



    public override void SetColor(Color newColor) {
        Renderer render = gameObject.GetComponent <Renderer>();
        if (render != null) {
            render.material.color = newColor;
        } else {
            Debug.LogWarning ("TessCube has no Renderer");
        }
    }
}

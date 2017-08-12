using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessNet : Tesseract {

    public bool isUnfolded = true;


    public override void OnClickTessCube(TessCube cube) {
        Debug.Log ("Clicked " + cube.gameObject.name);
        isUnfolded = !isUnfolded;
        ToggleCubes ();
    }


    void ToggleCubes() {
        for (int i = 1; i < cubes.Length; ++i) {
            cubes [i].SetVisible (isUnfolded);
        }
    }
}

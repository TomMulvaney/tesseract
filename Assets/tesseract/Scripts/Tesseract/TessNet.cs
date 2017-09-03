using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessNet : Tesseract {

    bool isUnfolded = true;
   
    public override void OnClickCube(TessCube cube) {
        isUnfolded = !isUnfolded;
        ToggleCubes ();
    }
        
    void ToggleCubes() {
        for (int i = 1; i < cubes.Length; ++i) {
            cubes [i].Enable (isUnfolded);
        }
    }
}

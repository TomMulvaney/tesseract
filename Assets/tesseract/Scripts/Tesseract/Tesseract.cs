using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseract : MonoBehaviour {

    public bool isUnfolded = true;

    public TessCube[] cubes = new TessCube[8];

    public Color[] colors = new Color[8];


	// Use this for initialization
	void Start () {
        for (int i = 0; i < cubes.Length; i++) {
            
            cubes [i].SetColor (colors [i]);
            cubes [i].OnClicked += OnClickTessCube;
        }
	}

    void OnClickTessCube(TessCube cube) {
        Debug.Log ("Clicked " + cube.gameObject.name);
        isUnfolded = !isUnfolded;
        ToggleCubes ();
    }


    void ToggleCubes() { // TODO: This function should be on child class TessNetCube
        for (int i = 1; i < cubes.Length; ++i) {
            cubes [i].SetVisible (isUnfolded);
        }
    }
}

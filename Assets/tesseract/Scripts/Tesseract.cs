using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseract : MonoBehaviour {

    public TessCube[] cubes = new TessCube[8];

    public Color[] colors = new Color[8];


	// Use this for initialization
	void Awake () {
        for (int i = 0; i < cubes.Length; i++) {
            
            cubes [i].SetColor (colors [i]);
            cubes [i].OnClicked += OnClickTessCube;
            cubes [i].TestOnClicked ();
        }
	}

    void OnClickTessCube(TessCube cube) {
        Debug.Log ("OnClickTessCube(): " + cube.gameObject.name);

    }
}

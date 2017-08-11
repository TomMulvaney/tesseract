using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseract : MonoBehaviour {

    public TessCube[] cubes = new TessCube[8];

    public Color[] colors = new Color[8];

    public Material mat;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < cubes.Length; i++) {
            mat.color = colors [i];
            cubes[i].SetMaterial (mat);
        }
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}

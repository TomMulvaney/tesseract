using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseract : MonoBehaviour {

    public TessCube[] cubes = new TessCube[8];

    public Color[] colors = new Color[8];


	// Use this for initialization
	void Start () {
        for (int i = 0; i < cubes.Length; i++) {
            cubes [i].GetComponent <Renderer> ().material.color = colors [i];
        }
	}
}

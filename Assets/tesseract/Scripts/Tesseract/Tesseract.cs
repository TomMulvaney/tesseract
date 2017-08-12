using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tesseract : MonoBehaviour {

    public TessCube[] cubes = new TessCube[8];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < cubes.Length; i++) {
            cubes [i].Init (i, cubes);
            cubes [i].OnClick += OnClickCube;
        }
    }

    public abstract void OnClickCube (TessCube cube);
}

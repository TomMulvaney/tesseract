using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tesseract : MonoBehaviour {

    bool hasStarted = false;
    public bool HasStarted() {
        return hasStarted;
    }

    [SerializeField]
    protected TessCube[] cubes = new TessCube[8];

    public TessCube[] GetCubes() {
        return cubes;
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < cubes.Length; i++) {
            cubes [i].Init (i, cubes);
            cubes [i].OnClick += OnClickCube;
        }

        hasStarted = true;
    }

    public abstract void OnClickCube (TessCube cube);
}

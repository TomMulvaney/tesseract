using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tesseract : MonoBehaviour {

    public TessCube[] cubes = new TessCube[8];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < cubes.Length; i++) {
            cubes [i].Init (i, cubes);
            cubes [i].OnClicked += OnClickTessCube;
        }

        SetCubeColors (TessRef.Instance.colors);
    }

    public abstract void OnClickTessCube (TessCube cube);

    public void SetCubeColors(Color[] colors) {
        if (colors.Length != cubes.Length) {
            Debug.LogError (string.Format ("Tesseract has {0} cubes but {1} colors", cubes.Length, colors.Length));
            return;
        }

        for (int i = 0; i < cubes.Length; i++) {
            cubes [i].SetColor (colors [i]);

        }
    }
}

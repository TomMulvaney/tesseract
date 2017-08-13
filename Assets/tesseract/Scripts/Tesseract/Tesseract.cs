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

        OffsetCubeColors (0); // TODO: This should not be done by Tesseract. TessCube should set own color in Init, TessCluster should handle changing color after that

        hasStarted = true;
    }

    public abstract void OnClickCube (TessCube cube);

    // TODO: Delete this method
    public void OffsetCubeColors(int off) {
        Color[] colors = new Color[8];

        // This is filth. Not only should you not be doing this manually, you definitely should be calculating inside TessRef
        colors [0] = TessRef.Instance.colors [off];
        colors [1] = TessRef.Instance.GetNeighborColor (off, TessRef.UP); // TODO: Tesseract should not know that 1 is UP. TessRef should handle this (TessRef.Up should probably equal 1 not "up"
        colors [2] = TessRef.Instance.GetNeighborColor (off, TessRef.LEFT);
        colors [3] = TessRef.Instance.GetNeighborColor (off, TessRef.FORWARD);
        colors [4] = TessRef.Instance.GetNeighborColor (off, TessRef.RIGHT);
        colors [5] = TessRef.Instance.GetNeighborColor (off, TessRef.BACK);
        colors [6] = TessRef.Instance.GetNeighborColor (off, TessRef.DOWN);
        colors [7] = TessRef.Instance.GetNeighborColor (off, TessRef.OPPOSITE);

        for (int i = 0; i < cubes.Length && i < colors.Length; i++) {
            cubes[i].SetColor (colors[i]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TessCube : MonoBehaviour {
    public TessNetCube forward;
    public TessNetCube back;

    public TessNetCube up;
    public TessNetCube down;

    public TessNetCube left;
    public TessNetCube right;

    public abstract void SetColor (Color newColor);
}

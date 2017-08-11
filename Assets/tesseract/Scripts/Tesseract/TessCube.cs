using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TessCube : MonoBehaviour {
    public delegate void ClickAction(TessCube cube);
    public event ClickAction OnClicked;

    public TessNetCube forward;
    public TessNetCube back;

    public TessNetCube up;
    public TessNetCube down;

    public TessNetCube left;
    public TessNetCube right;

    public abstract void SetColor (Color newColor);

    public void TestOnClicked() {
        if(OnClicked != null) {
            OnClicked (this);
        }
    }

    public virtual void Click() {
        if (OnClicked != null) {
            OnClicked (this);
        }
    }
}

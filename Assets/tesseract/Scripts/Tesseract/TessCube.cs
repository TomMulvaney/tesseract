using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TessCube : MonoBehaviour {

    public delegate void ClickAction(TessCube cube);
    public event ClickAction OnClicked;

    public int id;

    public TessCube forward;
    public TessCube back;

    public TessCube up;
    public TessCube down;

    public TessCube left;
    public TessCube right;

    public TessCube opposite;

    public void Init(int newId, TessCube[] cubes) {
        id = newId;
        SetNeighbors (cubes);
    }

    void SetNeighbors(TessCube[] cubes) {
        Dictionary<string, int> neighbors = TessRef.Instance.neighborMap [id];

        forward = cubes [neighbors [TessRef.FORWARD]];
        back = cubes [neighbors [TessRef.BACK]];

        left = cubes [neighbors [TessRef.LEFT]];
        right = cubes [neighbors [TessRef.RIGHT]];

        up = cubes [neighbors [TessRef.UP]];
        down = cubes [neighbors [TessRef.DOWN]];

        opposite = cubes [neighbors [TessRef.OPPOSITE]];
    }

    public abstract void SetColor (Color newColor);



    public virtual void Click() {
        if (OnClicked != null) {
            OnClicked (this);
        }
    }

    public abstract void SetVisible (bool isVisible);

}

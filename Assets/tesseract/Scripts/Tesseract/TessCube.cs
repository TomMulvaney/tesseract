using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessCube : MonoBehaviour {

    public delegate void ClickAction(TessCube cube);
    public event ClickAction OnClick;

    int id;

    public int GetId() {
        return id;
    }

    TessCube up;
    TessCube forward;
    TessCube right;
    TessCube back;
    TessCube left;
    TessCube down;
    TessCube opposite;


    protected void Click(IClickable clickable) {
        if (OnClick != null) {
            OnClick (this);
        }
    }
        
    public void Init(int newId, TessCube[] cubes) {
        id = newId;
        SetNeighbors (cubes);
        ChangeColor(0);
    }

    void SetNeighbors(TessCube[] cubes) {
        int[] neighbors = TessRef.Instance.neighborMap [id];

        up = cubes [neighbors [TessRef.UP]];
        forward = cubes [neighbors [TessRef.FORWARD]];
        right = cubes [neighbors [TessRef.RIGHT]];
        back = cubes [neighbors [TessRef.BACK]];
        left = cubes [neighbors [TessRef.LEFT]];
        down = cubes [neighbors [TessRef.DOWN]];
        opposite = cubes [neighbors [TessRef.OPPOSITE]];
    }

    // TODO: This should be reconceptualized more generally. You're not just changing the color, you're realigning so that a different cube is at the center
    public void ChangeColor(int newCenterColor) { 

        // TODO: Rooms have multiple renderers (4 walls).
        Renderer render = gameObject.GetComponent <Renderer>();

        if (render != null) {
            Color newColor = TessRef.Instance.GetNeighborColor (newCenterColor, id);
            render.material.color = newColor;
        } else {
            Debug.LogError ("Invoked OffsetColor on TessCube with no Renderer");
        }
    }
        
    public virtual void Enable (bool enabled) {
        float targetAlpha = enabled ? 1.0f : 0.0f;
        iTween.FadeTo (gameObject, targetAlpha, 0.3f);
    }
}

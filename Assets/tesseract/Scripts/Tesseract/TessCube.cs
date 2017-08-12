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

    TessCube forward;
    TessCube back;

    TessCube up;
    TessCube down;

    TessCube left;
    TessCube right;

    TessCube opposite;


    protected virtual void Awake() {
        Collider[] colliders = gameObject.GetComponentsInChildren <Collider> ();
        if (colliders.Length > 0) {
            foreach (Collider coll in colliders) {
                AssignClickable (coll);   
            }
        } else if (GetComponent<Collider>() != null) {
            AssignClickable (GetComponent<Collider>());
        } else {
            Debug.LogWarning ("TessCube has no collider nor colliders in children");
        }
    }

    void AssignClickable(Collider coll) {
        Clickable clickable = coll.gameObject.AddComponent <Clickable>();
        if (clickable != null) {
            clickable.OnClick += Click;
        } else {
            Debug.LogError ("TessCube failed to add Clickable component to collider");
        }
    }

    void Click(IClickable clickable) {
        if (OnClick != null) {
            OnClick (this);
        }
    }
        

    public void Init(int newId, TessCube[] cubes) {
        id = newId;
        SetNeighbors (cubes);
        OffsetColor (0);
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

    public void OffsetColor(int off) {
        Renderer render = gameObject.GetComponent <Renderer>();

        if (render == null) {
            Debug.LogError ("Invoked OffsetColor on TessCube with no Renderer");
            return;
        }

        int colorIdx = id + off;

        if (colorIdx >= TessRef.Instance.colors.Length) { // Wrap index
            colorIdx = off - TessRef.Instance.colors.Length - id - 1; // TODO: Test Index Wrapping
        }

        render.material.color = TessRef.Instance.colors [colorIdx];
    }


    public virtual void SetVisible (bool isVisible) {
        float targetAlpha = isVisible ? 1.0f : 0.0f;
        iTween.FadeTo (gameObject, targetAlpha, 0.3f);
    }
}

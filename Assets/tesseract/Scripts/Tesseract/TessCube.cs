using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessCube : MonoBehaviour {

    public List<Renderer> mainRenderers = new List<Renderer>();

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

    List<Collider> colliders = new List<Collider> ();

    void Awake() {
        Collider coll = gameObject.GetComponent <Collider> ();
        if (coll != null) {
            colliders.Add (coll);
        }

        Collider[] childColliders = gameObject.GetComponentsInChildren<Collider> ();
        foreach(Collider childColl in childColliders) {
            colliders.Add (childColl);
        }

        foreach (Collider collider in colliders) {
            Clickable clickable = collider.gameObject.AddComponent <Clickable>();
            if (clickable != null) {
                clickable.OnClick += Click;
            } else {
                Debug.LogError ("TessNetCube failed to add Clickable component to collider");
            }
        }
    }

    void Click(IClicker clicker, IClickable clickable) {
        if (OnClick != null) {
            OnClick (this);
        }
    }
        
    public void Init(int newId, TessCube[] cubes) {
        id = newId;
        SetNeighbors (cubes);
        Rebase(0);
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
        
    public void Rebase(int centerIdx) { 

        Color newColor = TessRef.Instance.GetNeighborColor (centerIdx, id);

        foreach (Renderer renderer in mainRenderers) {
            renderer.material.color = newColor;
        }
    }
        
    public void Enable (bool enabled) {
        float targetAlpha = enabled ? 1.0f : 0.0f;
        iTween.FadeTo (gameObject, targetAlpha, 0.3f);

        foreach (Collider collider in colliders) {
            collider.enabled = enabled;
        }
    }
}

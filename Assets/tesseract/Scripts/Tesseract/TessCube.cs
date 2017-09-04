using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessCube : MonoBehaviour {

    public List<Renderer> mainRenderers = new List<Renderer>();

    public delegate void RebaseAction(TessCube tessCube);
    public event RebaseAction OnRebase;

    public delegate void ClickAction(TessCube cube);
    public event ClickAction OnClick;

    int id;

    public int GetId() {
        return id;
    }

    Color color;

    public Color GetColor() {
        return color;
    }

    protected TessCube[] neighbors = new TessCube[8];

    protected TessCube up;
    protected TessCube forward;
    protected TessCube right;
    protected TessCube back;
    protected TessCube left;
    protected TessCube down;
    protected TessCube opposite;

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
        
    public virtual void Init(int newId, TessCube[] cubes) {
        id = newId;
        SetNeighbors (cubes);
        Rebase(0);
    }

    void SetNeighbors(TessCube[] cubes) {
        int[] neighborIdxs = TessRef.Instance.neighborMap [id];

        for (int i = 0; i < neighbors.Length; ++i) {
            neighbors [i] = cubes [neighborIdxs [i]];
        }
    }
        
    public virtual void Rebase(int centerIdx) { 

        color = TessRef.Instance.GetNeighborColor (centerIdx, id);

        foreach (Renderer renderer in mainRenderers) {
            renderer.material.color = color;
        }

        if (OnRebase != null) {
            OnRebase (this);
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

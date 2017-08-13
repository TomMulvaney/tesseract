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

    List<Collider> colliders = new List<Collider>();


    protected virtual void Awake() {
        Collider[] childColliders = gameObject.GetComponentsInChildren <Collider> ();
        foreach (Collider childCollider in childColliders) {
            AddCollider (childCollider);   
        }

        Collider collider = GetComponent<Collider>();
        if (collider != null) {
            AddCollider (GetComponent<Collider>());
        }

        if (colliders.Count == 0) {
            Debug.LogWarning ("TessCube has no colliders");
        }
    }

    void AddCollider(Collider collider) {
        Clickable clickable = collider.gameObject.AddComponent <Clickable>();
        if (clickable != null) {
            clickable.OnClick += Click;
            colliders.Add (collider);
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
        // TODO: ChangeColor(0);
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

    public void ChangeColor(int newCenterColor) {
        // TODO: Get new color from TessRef given this TessCube's id and the newCenterColor
    }

    // TODO: Delete
    public void SetColor(Color color) { // TODO: This is not relevant to rooms, but is relevant to multiple types of tesseract (does it belong here?)
        Renderer render = gameObject.GetComponent <Renderer>();

        if (render == null) {
            Debug.LogError ("Invoked OffsetColor on TessCube with no Renderer");
            return;
        }

        render.material.color = color; // TODO: Rooms have multiple renderers (4 walls).
    }
     


    public virtual void SetVisible (bool isVisible) {
        float targetAlpha = isVisible ? 1.0f : 0.0f;
        iTween.FadeTo (gameObject, targetAlpha, 0.3f);

        foreach (Collider collider in colliders) {
            collider.enabled = isVisible;
        }
    }
}

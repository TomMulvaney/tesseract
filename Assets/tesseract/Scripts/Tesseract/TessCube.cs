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

    public TessCube up;
    public TessCube forward;
    public TessCube right;
    public TessCube back;
    public TessCube left;
    public TessCube down;
    public TessCube opposite;


    List<Collider> colliders = new List<Collider>();

    // TODO: Collider and Clickable logic go in TessNetCube class (inherits from TessCube)


    protected virtual void Awake() {
        // The collider logic is all wrong. Not all colliders are supposed to be clickable (e.g. In TessCubeRoom, walls and portals both have colliders, but only portals are clickable)

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
        
    public virtual void SetVisible (bool isVisible) {
        float targetAlpha = isVisible ? 1.0f : 0.0f;
        iTween.FadeTo (gameObject, targetAlpha, 0.3f);

        foreach (Collider collider in colliders) {
            collider.enabled = isVisible;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessCube : MonoBehaviour {

    public TessCube forward;
    public TessCube back;

    public TessCube up;
    public TessCube down;

    public TessCube left;
    public TessCube right;


    public MeshRenderer render;

	// Use this for initialization
	void Start () {
        render = gameObject.GetComponent <MeshRenderer> ();
        if (render == null) {
            Debug.LogWarning ("TessCube has no MeshRenderer");
        }
	}

    public void SetMaterial(Material newMat) {
        if (render != null) {
            render.material = newMat;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

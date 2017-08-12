using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessCluster : MonoBehaviour {

    public List<Tesseract> tesseracts = new List<Tesseract>();

	// Use this for initialization
	void Start () {
        if (tesseracts.Count <= 8) {
            for (int i = 0; i < tesseracts.Count; ++i) {
                TessCube[] cubes = tesseracts [i].GetCubes ();
                foreach (TessCube cube in cubes) {
                    cube.OffsetColor (i);
                }
            }
        } else {
            Debug.LogError (string.Format ("TessCluster has {0} tesseracts", tesseracts.Count));
        }
	}
}

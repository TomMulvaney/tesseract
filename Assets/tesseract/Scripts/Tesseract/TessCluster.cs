using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TessCluster : MonoBehaviour {

    public List<Tesseract> tesseracts = new List<Tesseract>();

	// Use this for initialization
    IEnumerator Start () {
        if (tesseracts.Count > 0 && tesseracts.Count <= 8) {
            yield return new WaitUntil(() => tesseracts.All (tess => tess.HasStarted ()));
            for (int i = 0; i < tesseracts.Count; ++i) {
                tesseracts [i].OffsetCubeColors (i);
//                TessCube[] cubes = tesseracts [i].GetCubes ();
//                foreach (TessCube cube in cubes) {
//                    cube.OffsetColor (i);
//                }
            }
        } else {
            Debug.LogError (string.Format ("TessCluster has {0} tesseracts", tesseracts.Count));
        }
	}
        
}

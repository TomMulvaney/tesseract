using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TessRef : Singleton<TessRef> {

    public Color[] colors = new Color[8];

    public readonly int[][] neighborMap = new int[8][];

    public const int CENTER = 0;
    public const int UP = 1;
    public const int FORWARD = 2;
    public const int RIGHT = 3;
    public const int BACK = 4;
    public const int LEFT = 5;
    public const int DOWN = 6;
    public const int OPPOSITE = 7;


    public int GetNeighborId(int id, int direction) {
        return neighborMap [id][direction];
    }

    public Color GetNeighborColor(int id, int direction) {
        int neighborId = GetNeighborId (id, direction);
        return colors [neighborId];
    }


	// Use this for initialization
	void Awake () {
        for(int i = 0; i < neighborMap.Length; i++){
            int[] neighbors = new int[8];

            switch (i) {
            case 0:
                neighbors [CENTER] = 0;
                neighbors [UP] = 1;
                neighbors [FORWARD] = 2;
                neighbors [RIGHT] = 3;
                neighbors [BACK] = 4;
                neighbors [LEFT] = 5;
                neighbors [DOWN] = 6;
                neighbors [OPPOSITE] = 7;
                break;
            case 1:
                neighbors [CENTER] = 1; // Each cube is its own "center"
                neighbors [UP] = 7;
                neighbors [FORWARD] = 2;
                neighbors [RIGHT] = 3;
                neighbors [BACK] = 4;
                neighbors [LEFT] = 5;
                neighbors [DOWN] = 0;
                neighbors [OPPOSITE] = 6;
                break;
            case 2:
                neighbors [CENTER] = 2;
                neighbors [UP] = 1;
                neighbors [FORWARD] = 7;
                neighbors [RIGHT] = 3;
                neighbors [BACK] = 0;
                neighbors [LEFT] = 5;
                neighbors [DOWN] = 6;
                neighbors [OPPOSITE] = 4;
                break;
            case 3:
                neighbors [CENTER] = 3;
                neighbors [UP] = 1;
                neighbors [FORWARD] = 2;
                neighbors [RIGHT] = 7;
                neighbors [BACK] = 4;
                neighbors [LEFT] = 0;
                neighbors [DOWN] = 6;
                neighbors [OPPOSITE] = 5;
                break;
            case 4:
                neighbors [CENTER] = 4;
                neighbors [UP] = 1;
                neighbors [FORWARD] = 0;
                neighbors [RIGHT] = 3;
                neighbors [BACK] = 7;
                neighbors [LEFT] = 5;
                neighbors [DOWN] = 6;
                neighbors [OPPOSITE] = 2;
                break;
            case 5:
                neighbors [CENTER] = 5;
                neighbors [UP] = 1;
                neighbors [FORWARD] = 2;
                neighbors [RIGHT] = 0;
                neighbors [BACK] = 4;
                neighbors [LEFT] = 7;
                neighbors [DOWN] = 6;
                neighbors [OPPOSITE] = 3;
                break;
            case 6:
                neighbors [CENTER] = 6;
                neighbors [UP] = 0;
                neighbors [FORWARD] = 2;
                neighbors [RIGHT] = 3;
                neighbors [BACK] = 4;
                neighbors [LEFT] = 5;
                neighbors [DOWN] = 7;
                neighbors [OPPOSITE] = 1;
                break;
            case 7:
                neighbors [CENTER] = 7;
                neighbors [UP] = 6;
                neighbors [FORWARD] = 2;
                neighbors [RIGHT] = 3;
                neighbors [BACK] = 4;
                neighbors [LEFT] = 5;
                neighbors [DOWN] = 1;
                neighbors [OPPOSITE] = 0;
                break;
            }

            int[] uniqueNeighbors = neighbors.Distinct ().ToArray ();

            if (neighbors.Length != uniqueNeighbors.Length) {
                Debug.LogError ("Neighbors not unique for " + i.ToString ());
            }

            neighborMap[i] = neighbors;
        }
	}

}

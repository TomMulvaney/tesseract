using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessRef : Singleton<TessRef> {

    public Color[] colors = new Color[8];

    // TODO: Should be Dictionary<int, int>
    public readonly Dictionary<string, int>[] neighborMap = new Dictionary<string, int>[8];

    public const string FORWARD = "forward"; // TODO: This should be ints
    public const string BACK = "back";
    public const string UP = "up";
    public const string DOWN = "down";
    public const string LEFT = "left";
    public const string RIGHT = "right";
    public const string OPPOSITE = "opposite";


    // 0 = Center
    // 1 = Top
    // 2 = Left
    // 3 = Right
    // 4 = Forward
    // 5 = Back
    // 6 = Lower-center
    // 7 = Bottom

    public int GetNeighborId(int id, string direction) {
        Dictionary<string, int> neighbors = neighborMap [id];
        return neighbors [direction];
    }

    public Color GetNeighborColor(int id, string direction) {
        int neighborId = GetNeighborId (id, direction);
        return colors [neighborId];
    }


	// Use this for initialization
	void Awake () {
        for(int i = 0; i < neighborMap.Length; i++){
            Dictionary<string, int> neighbors = new Dictionary<string, int> ();

            switch (i) {
            case 0:
                neighbors [UP] = 1;
                neighbors [DOWN] = 6;
                neighbors [LEFT] = 2;
                neighbors [RIGHT] = 4;
                neighbors [FORWARD] = 3;
                neighbors [BACK] = 5;
                neighbors [OPPOSITE] = 7;
                break;
            case 1:
                neighbors [UP] = 7;
                neighbors [DOWN] = 0;
                neighbors [LEFT] = 2;
                neighbors [RIGHT] = 4;
                neighbors [FORWARD] = 3;
                neighbors [BACK] = 5;
                neighbors [OPPOSITE] = 6;
                break;
            case 2:
                neighbors [UP] = 1;
                neighbors [DOWN] = 6;
                neighbors [LEFT] = 7;
                neighbors [RIGHT] = 0;
                neighbors [FORWARD] = 3;
                neighbors [BACK] = 5;
                neighbors [OPPOSITE] = 4;
                break;
            case 3:
                neighbors [UP] = 1;
                neighbors [DOWN] = 6;
                neighbors [LEFT] = 2;
                neighbors [RIGHT] = 4;
                neighbors [FORWARD] = 7;
                neighbors [BACK] = 0;
                neighbors [OPPOSITE] = 5;
                break;
            case 4:
                neighbors [UP] = 1;
                neighbors [DOWN] = 6;
                neighbors [LEFT] = 0;
                neighbors [RIGHT] = 7;
                neighbors [FORWARD] = 3;
                neighbors [BACK] = 5;
                neighbors [OPPOSITE] = 2;
                break;
            case 5:
                neighbors [UP] = 1;
                neighbors [DOWN] = 6;
                neighbors [LEFT] = 2;
                neighbors [RIGHT] = 4;
                neighbors [FORWARD] = 0;
                neighbors [BACK] = 7;
                neighbors [OPPOSITE] = 3;
                break;
            case 6:
                neighbors [UP] = 0;
                neighbors [DOWN] = 7;
                neighbors [LEFT] = 2;
                neighbors [RIGHT] = 4;
                neighbors [FORWARD] = 3;
                neighbors [BACK] = 5;
                neighbors [OPPOSITE] = 1;
                break;
            case 7:
                neighbors [UP] = 6;
                neighbors [DOWN] = 1;
                neighbors [LEFT] = 2;
                neighbors [RIGHT] = 4;
                neighbors [FORWARD] = 3;
                neighbors [BACK] = 5;
                neighbors [OPPOSITE] = 0;
                break;
            }

            neighborMap[i] = neighbors;
        }
	}

}

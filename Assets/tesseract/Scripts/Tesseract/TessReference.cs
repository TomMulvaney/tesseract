using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessReference : Singleton<TessReference> {

    public Color[] colors = new Color[8];

    public readonly Dictionary<string, int>[] cubes = new Dictionary<string, int>[8];

    public const string FORWARD = "forward";
    public const string BACK = "back";
    public const string UP = "up";
    public const string DOWN = "down";
    public const string LEFT = "left";
    public const string RIGHT = "right";
    public const string OPPOSITE = "opposite";


	// Use this for initialization
	void Awake () {
        for(int i = 0; i < cubes.Length; i++){
            Dictionary<string, int> cube = new Dictionary<string, int> ();

            switch (i) {
            case 0:
                cube [UP] = 1;
                cube [DOWN] = 6;
                cube [LEFT] = 2;
                cube [RIGHT] = 4;
                cube [FORWARD] = 3;
                cube [BACK] = 5;
                cube [OPPOSITE] = 7;
                break;
            case 1:
                cube [UP] = 7;
                cube [DOWN] = 0;
                cube [LEFT] = 2;
                cube [RIGHT] = 4;
                cube [FORWARD] = 3;
                cube [BACK] = 5;
                cube [OPPOSITE] = 6;
                break;
            case 2:
                cube [UP] = 1;
                cube [DOWN] = 6;
                cube [LEFT] = 7;
                cube [RIGHT] = 0;
                cube [FORWARD] = 3;
                cube [BACK] = 5;
                cube [OPPOSITE] = 4;
                break;
            case 3:
                cube [UP] = 1;
                cube [DOWN] = 6;
                cube [LEFT] = 2;
                cube [RIGHT] = 4;
                cube [FORWARD] = 7;
                cube [BACK] = 0;
                cube [OPPOSITE] = 5;
                break;
            case 4:
                cube [UP] = 1;
                cube [DOWN] = 6;
                cube [LEFT] = 0;
                cube [RIGHT] = 7;
                cube [FORWARD] = 3;
                cube [BACK] = 5;
                cube [OPPOSITE] = 2;
                break;
            case 5:
                cube [UP] = 1;
                cube [DOWN] = 6;
                cube [LEFT] = 2;
                cube [RIGHT] = 4;
                cube [FORWARD] = 0;
                cube [BACK] = 7;
                cube [OPPOSITE] = 3;
                break;
            case 6:
                cube [UP] = 0;
                cube [DOWN] = 7;
                cube [LEFT] = 2;
                cube [RIGHT] = 4;
                cube [FORWARD] = 3;
                cube [BACK] = 5;
                cube [OPPOSITE] = 1;
                break;
            case 7:
                cube [UP] = 6;
                cube [DOWN] = 1;
                cube [LEFT] = 2;
                cube [RIGHT] = 4;
                cube [FORWARD] = 3;
                cube [BACK] = 5;
                cube [OPPOSITE] = 0;
                break;
            }

            cubes[i] = cube;
        }
	}

}

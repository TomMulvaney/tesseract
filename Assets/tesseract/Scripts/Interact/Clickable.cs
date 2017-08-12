using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

    public delegate void ClickAction(Clickable cube);
    public event ClickAction OnClick;

    void Click(IClickable clickable) {
        if (OnClick != null) {
            OnClick (this);
        }
    }
}

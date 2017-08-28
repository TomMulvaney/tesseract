using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour, IClickable {

    public delegate void ClickAction(IClickable cube);
    public event ClickAction OnClick;

    public void Click(MonoBehaviour obj) {
        if (OnClick != null) {
            OnClick (this as IClickable); // TODO: Pass Clickable and Clicker
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour, IClickable {

    public delegate void ClickAction(IClicker clicker, IClickable clickable);
    public event ClickAction OnClick;

    public void Click(IClicker clicker) {
        if (OnClick != null) {
            OnClick (clicker, this as IClickable);
        }
    }

    public GameObject GetGameObject() {
        return gameObject;
    }
}

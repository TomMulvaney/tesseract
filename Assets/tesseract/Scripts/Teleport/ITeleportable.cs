using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeleportable {

    void Teleport (Transform target, TeleportTransition transition);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessRoom : TessCube {

    public Transform playerPosition;

    public TessRoomPortal[] portals = new TessRoomPortal[6];

    public override void Init(int newId, TessCube[] cubes) {
        base.Init (newId, cubes);

        for (int i = 0; i < portals.Length; ++i) {
            // PortalIdx = NeighborIdx - 1 (e.g. Up=1 but PortalIdx=0) because there is no "self" portal
            portals [i].SetMoveTarget (((TessRoom)neighbors [i + 1]).GetPlayerPosition ());
        }
    }

    public override void Rebase(int centerIdx) {
        base.Rebase (centerIdx);

//        for (int i = 0; i < portals.Length; ++i) {
//            int neighborIdx = TessRef.Instance.GetNeighborId (centerIdx, i + 1);
//            Color portalColor = TessRef.Instance.GetNeighborColor ()
//        }
    }

    public Transform GetPlayerPosition() {
        return playerPosition;
    }
}

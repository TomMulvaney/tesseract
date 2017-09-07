using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessRoom : TessCube {

    public Transform playerPosition;

    // TODO: Get portals from GetComponentsInChildren, then sort by calling TessReff.SortByLocalSpace

    // PortalIdx = NeighborIdx - 1 (e.g. Up=1 but PortalIdx=0) because there is no "self" portal
    public TessRoomPortal[] portals = new TessRoomPortal[6];

    public override void Init(int newId, TessCube[] cubes) {
        base.Init (newId, cubes);

        for (int i = 0; i < portals.Length; ++i) {
            portals [i].SetMoveTarget (((TessRoom)neighbors [i + 1]).GetPlayerPosition ());
        }
    }

    public override void Rebase(int centerIdx) {
        base.Rebase (centerIdx);

        int thisIdx = TessRef.Instance.GetNeighborId (centerIdx, GetId ());

        for (int i = 0; i < portals.Length; ++i) {
            Color portalColor = TessRef.Instance.GetNeighborColor (thisIdx, i + 1);
            portals [i].SetColor (portalColor);
        }
    }

    public Transform GetPlayerPosition() {
        return playerPosition;
    }
}

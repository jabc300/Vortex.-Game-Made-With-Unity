using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysData
{
    public string LeftMovement { get; set; }
    public string RightMovement { get; set; }
    public string Vortex { get; set; }
    public string Laser { get; set; }
    public string Shield { get; set; }

    public KeysData() {
        LeftMovement = KeysManager.Keys[0];
        RightMovement = KeysManager.Keys[1];
        Vortex = KeysManager.Keys[2];
        Laser = KeysManager.Keys[3];
        Shield = KeysManager.Keys[4];
    }
}

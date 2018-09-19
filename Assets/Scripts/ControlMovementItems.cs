using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovementItems  {
    public enum itemSide
    {
        LEFT_SIDE, RIGHT_SIDE, NONE
    }
    // Use this for initialization
    private itemSide side;

    public itemSide Side
    {
        get
        {
            return side;
        }

        set
        {
            side = value;
        }
    }
}

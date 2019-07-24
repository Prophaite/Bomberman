using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleMap : MonoBehaviour
{
    enum destructibleObject {Wall = -1, Nothing, DestrucibleWall, Loot, Bomb};
    public int[,] map = new int[11,11]{{0,0,0,0,0,0,0,0,0,0,0},
        {0,-1,0,-1,0,-1,0,-1,0,-1,0},
        {0,0,0,0,0,0,0,0,0,0,0},
        {0,-1,0,-1,0,-1,0,-1,0,-1,0},
        {0,0,0,0,0,0,0,0,0,0,0},
        {0,-1,0,-1,0,-1,0,-1,0,-1,0},
        {0,0,0,0,0,0,0,0,0,0,0},
        {0,-1,0,-1,0,-1,0,-1,0,-1,0},
        {0,0,0,0,0,0,0,0,0,0,0},
        {0,-1,0,-1,0,-1,0,-1,0,-1,0},
        {0,0,0,0,0,0,0,0,0,0,0}
    };

}

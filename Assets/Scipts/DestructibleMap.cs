using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DestructibleMap 
{
    public enum destructibleObject {Wall = -1, Nothing = 0, DestrucibleWall = 1, Loot = 2, Bomb = 3};
    public static int[,] map = new int[11,11]{{0,0,0,0,0,0,0,0,0,0,0},
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

    public static bool FreePlaceOnMap(int x, int y){
        if(x<0 || x>10 || y<0 || y>10 || map[x,y] != 0){return false;}
        return true;
    }

    public static void AddWallOnMap(int x, int y){
        if(x<0 || x>10 || y<0 || y>10 || map[x,y] == -1){return;}
        map[x,y] = -1;
    }

    public static void AddDestructibleWallOnMap(int x, int y){
        if(!FreePlaceOnMap(x,y)){return;}
        map[x,y] = 1;
    }

    public static void AddLootOnMap(int x, int y){
        if(!FreePlaceOnMap(x,y)){return;}
        map[x,y] = 2;
    }

    public static void AddBombOnMap(int x, int y){
        if(!FreePlaceOnMap(x,y)){return;}
        map[x,y] = 3;
    }

    public static void RemoveObjectFromMap(int x, int y){
        if(x<0 || x>10 || y<0 || y>10 || map[x,y] == -1){return;}
        map[x,y] = 0;
    }

}

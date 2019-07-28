using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ObjectOnTilemap
{
    private int fireRadius;

    [SerializeField]
    public Bomb bomb;
    public int maxNumberBomb = 1;
    public int actualNumberBomb = 0;
    //public DestructibleMap destructibleMap;

    void Start(){

    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
           CreateBomb();
        }
    }

    private void CreateBomb(){
        if(actualNumberBomb >= maxNumberBomb){return;}
        Vector3Int bombPlacement = GetPositionOnTilemap();
        bool testCreationBomb = DestructibleMap.FreePlaceOnMap((int) bombPlacement.x,(int) bombPlacement.y);
        if(testCreationBomb){
            Bomb bombObject = Instantiate(bomb,GetPosition(),Quaternion.identity);
            DestructibleMap.AddBombOnMap(bombPlacement.x, bombPlacement.y);
            bombObject.player = this;
            actualNumberBomb++;
        }
    }

    
}

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
    public DestructibleMap destructibleMap;

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
        Vector3 bombPlacement = GetPositionOnTilemap();
        if(destructibleMap.map[(int) bombPlacement.x,(int) bombPlacement.y] != 0){
            return;
        }
        Bomb bombObject = Instantiate(bomb,GetPosition(),Quaternion.identity);
        bombObject.player = this;
        actualNumberBomb++;
    }

    
}

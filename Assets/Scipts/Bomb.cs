using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : ObjectOnTilemap
{
    public SpriteRenderer sr;
    public Player player;
    private float timer;
    private float bombTimer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timer + bombTimer){
            Explode();
        }


    }

    public void Explode(){
        Vector3Int bombPlacement = GetPositionOnTilemap();
        Destroy(this.gameObject);
        DestructibleMap.RemoveObjectFromMap(bombPlacement.x, bombPlacement.y);
        if(player != null){
            player.actualBombNumber--;
        }
    }
}

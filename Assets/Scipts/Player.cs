using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingEntity
{
    private int fireRadius;
    private float horizontal;
    private float vertical;

    [SerializeField]
    public Bomb bomb;
    public int numberBomb = 1;

    protected override void Start(){
        base.Start();
        moveSpeed = 5;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f){
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            Vector2 test = new Vector2(horizontal, vertical);
            AttemptMove(test);
        }

        if(Input.GetKey("space")){
            CreateBomb();
        }
    
    }

    private void CreateBomb(){
        Instantiate(bomb,GetPositionPlayer(),Quaternion.identity);
    }

    private Vector3 GetPositionPlayer(){
        Vector3 pos = rb2D.position;
        int x;
        int y;
        if(pos.x < 0){
            x = (int) pos.x - 1;
        }
        else{
            x = (int) pos.x;
        }

        if(pos.y < 0){
            y = (int) pos.y - 1;
        }
        else{
            y = (int) pos.y;
        }
        pos.x = x + 0.5f;
        pos.y = y + 0.5f;
        return pos;
    }
}

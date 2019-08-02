using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBombGenerator : MonoBehaviour
{
    public Bomb bomb;
    private int maxBomb;
    private float delay;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        maxBomb = 3;
        delay = 5f;
        GenerateBombLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(maxBomb > 96){
            maxBomb = 96;
        }
        if(Time.time >= timer + delay){
            GenerateBombLevel();
        }
    }

    void PutBomb(){
        int row = 0;
        int column = 0;
        do{
            row = (int) Random.Range(0,11);
            column = (int) Random.Range(0,11);
            if(row % 2 == 1 && column % 2 == 1){
                column++;
            }
        }while(DestructibleMap.Map(row, column) != 0);
        DestructibleMap.AddBombOnMap(row,column);

        Vector3 positionBomb = new Vector3(row - 4.5f, -column + 4.5f, 0f);
        Vector3 test = Vector3.zero;
        Instantiate(bomb,positionBomb, Quaternion.identity);
    }

    private void GenerateBombLevel(){
        for(int i = 0; i < maxBomb; i++){
            PutBomb();
        }
        timer = Time.time;
        if(maxBomb < 96){
            maxBomb += 5;
        }
        
    }

}

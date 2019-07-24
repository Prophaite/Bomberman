using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBombGenerator : MonoBehaviour
{
    public Bomb bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //générer au bon moment
        PutBomb();
    }

    void PutBomb(){
        int row = (int) Random.Range(0,11);
        int column = (int) Random.Range(0,11);
        if(row % 2 == 1 && column % 2 == 1){
            column++;
        }

        Vector3 positionBomb = new Vector3(row - 4.5f, -column + 4.5f, 0f);
        Vector3 test = Vector3.zero;
        Instantiate(bomb,positionBomb, Quaternion.identity);
    }
}

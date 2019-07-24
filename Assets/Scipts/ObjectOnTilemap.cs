using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnTilemap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPosition(){
        Vector3 pos = transform.position;
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

    public Vector3 GetPositionOnTilemap(){
        Vector3 pos = GetPosition();
        pos.x = pos.x + 4.5f;
        pos.y = 4.5f - pos.y;
        return pos;
    }
}

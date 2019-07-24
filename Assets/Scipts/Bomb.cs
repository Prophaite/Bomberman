using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : ObjectOnTilemap
{
    public SpriteRenderer sr;
    public Player player;
    [SerializeField]
    private Color normalTimeColor;
    [SerializeField] 
    private Color redTimeColor;
    private bool isRedTime;
    private float redTimer = 0.5f;
    private float timer;
    private int redTimeCountMax = 2;
    private int redTimeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        isRedTime = false;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > (timer + redTimer)){
            timer = Time.time;
            ChangeRedTime();
            if(isRedTime){
                sr.color = redTimeColor;
            }
            else{
                sr.color = normalTimeColor;
                redTimeCount++;
            }
        }

        if(redTimeCount == redTimeCountMax){
            Explose();
        }
    }

    public void ChangeRedTime(){
        isRedTime = !isRedTime;
    }

    public void Explose(){
        Destroy(this.gameObject);
        if(player != null){
            player.actualNumberBomb--;
        }
    }
}

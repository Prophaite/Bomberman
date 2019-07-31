using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private Animator anim;
    private AnimationEvent evt;
    private float timer;
    private float animDuration = 0.583f;
    
    public Vector3Int bombPosition;
    public int range;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timer + animDuration){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.SendMessage("Kill");
        }

        if(other.gameObject.tag == "Bomb"){
            other.gameObject.SendMessage("Explode");
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : ObjectOnTilemap
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public Player player;
    private BoxCollider2D colliderPlayer;
    private float timer;
    private float bombTimer = 3.0f;
    [SerializeField]
    private BombExplosion bombExplosion;
    private Vector3Int bombPlacement;
    private int rangeOfFire = 3;

    // Start is called before the first frame update
    void Start()
    {
        
        timer = Time.time;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        bombPlacement = GetPositionOnTilemap();
        if(player != null){
            rangeOfFire = player.rangeOfFire;
        }
        //Debug.Log(GameObject.Find("Player").gameObject != null);
        if(GameObject.Find("Player") != null){
            colliderPlayer = GameObject.Find("Player").GetComponent<BoxCollider2D>();
            if(!bc.IsTouching(colliderPlayer)){
                bc.isTrigger = false;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(Time.time >= timer + bombTimer){
            Explode();
        }
    }

    public void Explode(){
        Destroy(this.gameObject);
        DestructibleMap.RemoveObjectFromMap(bombPlacement.x, bombPlacement.y);
        if(player != null){
            player.actualBombNumber--;
        }
        SetExplosion();
    }

    void SetExplosion(){
        Instantiate(bombExplosion, GetPosition(), Quaternion.identity);
        SetExplosionRight();
        SetExplosionLeft();
        SetExplosionUp();
        SetExplosionDown();
    }

    private int ExplosionCheckRight(){
        if(Math.Min(rangeOfFire, 10 - bombPlacement.x) == 0){return 0;}
        int i = 1;
        while(i < Math.Min(rangeOfFire, 10 - bombPlacement.x)){
            if(DestructibleMap.Map(bombPlacement.x + i, bombPlacement.y) == -1){
                return i - 1;
            }
            if(DestructibleMap.Map(bombPlacement.x + i, bombPlacement.y) >= 1){
                i++;
                return i;
            }
            i++;
        }
        return i;
    }

    private void SetExplosionRight(){
        if(ExplosionCheckRight() == 0){
            return;
        }
        Vector3 realPosition = GetPosition();
        for(int i=1; i <= ExplosionCheckRight(); i++){
            Instantiate(bombExplosion, new Vector3(realPosition.x + i, realPosition.y, 0), Quaternion.identity);
        }
    }

    private int ExplosionCheckLeft(){
        if(Math.Min(rangeOfFire, bombPlacement.x) == 0){return 0;}
        int i = 1;
        while(i < Math.Min(rangeOfFire, bombPlacement.x)){
            if(DestructibleMap.Map(bombPlacement.x - i, bombPlacement.y) == -1){
                return i - 1;
            }
            if(DestructibleMap.Map(bombPlacement.x - i, bombPlacement.y) >= 1){
                i++;
                return i;
            }
            i++;
        }
        return i;
    }

    private void SetExplosionLeft(){
        if(ExplosionCheckLeft() == 0){
            return;
        }
        Vector3 realPosition = GetPosition();
        for(int i=1; i <= ExplosionCheckLeft(); i++){
            Instantiate(bombExplosion, new Vector3(realPosition.x - i, realPosition.y, 0), Quaternion.identity);
        }
    }

    private int ExplosionCheckUp(){
        if(Math.Min(rangeOfFire, bombPlacement.y) == 0){return 0;}
        int i = 1;
        while(i < Math.Min(rangeOfFire, bombPlacement.y)){
            if(DestructibleMap.Map(bombPlacement.x, bombPlacement.y - i) == -1){
                return i - 1;
            }
            if(DestructibleMap.Map(bombPlacement.x, bombPlacement.y - i) >= 1){
                i++;
                return i;
            }
            i++;
        }
        return i;
    }

    private void SetExplosionUp(){
        if(ExplosionCheckUp() == 0){
            return;
        }
        Vector3 realPosition = GetPosition();
        for(int i=1; i <= ExplosionCheckUp(); i++){
            Instantiate(bombExplosion, new Vector3(realPosition.x, realPosition.y + i, 0), Quaternion.identity);
        }
    }

    private int ExplosionCheckDown(){
        if(Math.Min(rangeOfFire, 10 - bombPlacement.y) == 0){return 0;}
        int i = 1;
        while(i < Math.Min(rangeOfFire, 10 - bombPlacement.y)){
            if(DestructibleMap.Map(bombPlacement.x, bombPlacement.y + i) == -1){
                return i - 1;
            }
            if(DestructibleMap.Map(bombPlacement.x, bombPlacement.y + i) >= 1){
                i++;
                return i;
            }
            i++;
        }
        return i;
    }

    private void SetExplosionDown(){
        if(ExplosionCheckDown() == 0){
            return;
        }
        Vector3 realPosition = GetPosition();
        for(int i=1; i <= ExplosionCheckDown(); i++){
            Instantiate(bombExplosion, new Vector3(realPosition.x, realPosition.y - i, 0), Quaternion.identity);
        }
    }

    

    void OnTriggerExit2D(Collider2D other){
        if(player != null){
            if(other.gameObject.tag == "Player"){
               bc.isTrigger = false; 
            }
        }        
    }
}

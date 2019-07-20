using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
	protected Rigidbody2D rb2D;
	[SerializeField]
	protected int moveSpeed;
	public Guid ID;

    private int offsetValue = 1;


    // Start is called before the first frame update
    protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D>();
		ID = Guid.NewGuid();
        moveSpeed = 1;
	}

    // Update is called once per frame
    void Update()
    {
		
        
    }

    public void AttemptMove(Vector2 testMove){
		//def des directions
		bool canMoveRight = true;
		bool canMoveLeft = true;
		bool canMoveTop = true;
		bool canMoveBot = true;

		// bloquer les directions
		//droite
		this.GetComponent<Collider2D>().enabled = false;
		RaycastHit2D topRightH = Physics2D.Raycast(transform.position + new Vector3(0.25f,0.25f,0f), Vector2.right, offsetValue * Time.deltaTime * moveSpeed);
		RaycastHit2D botRightH = Physics2D.Raycast(transform.position + new Vector3(0.25f,-0.4f,0f), Vector2.right, offsetValue * Time.deltaTime * moveSpeed);

		//gauche
		RaycastHit2D topLeftH = Physics2D.Raycast(transform.position + new Vector3(-0.25f,0.25f,0f), Vector2.left, offsetValue * Time.deltaTime * moveSpeed);
		RaycastHit2D botLeftH = Physics2D.Raycast(transform.position + new Vector3(-0.25f,-0.4f,0f), Vector2.left, offsetValue * Time.deltaTime * moveSpeed);

		//haut
		RaycastHit2D topLeftV = Physics2D.Raycast(transform.position + new Vector3(-0.25f,0.3f,0f), Vector2.up, offsetValue * Time.deltaTime * moveSpeed);
		RaycastHit2D topRightV = Physics2D.Raycast(transform.position + new Vector3(0.25f,0.3f,0f), Vector2.up, offsetValue * Time.deltaTime * moveSpeed);

		//bas
		RaycastHit2D botLeftV = Physics2D.Raycast(transform.position + new Vector3(-0.25f,-0.45f,0f), Vector2.down, offsetValue * Time.deltaTime * moveSpeed);
		RaycastHit2D botRightV = Physics2D.Raycast(transform.position + new Vector3(0.25f,-0.45f,0f), Vector2.down, offsetValue * Time.deltaTime * moveSpeed);
		this.GetComponent<Collider2D>().enabled = true;

		//droite
		if(topRightH.collider != null){
			if(topRightH.collider.gameObject.layer == 8 && testMove.x > 0){
				canMoveRight = false;
			}
		}
		if(botRightH.collider != null){
			if(botRightH.collider.gameObject.layer == 8 && testMove.x > 0){
				canMoveRight = false;
			}
		}

		//gauche
		if(topLeftH.collider != null){
			if(topLeftH.collider.gameObject.layer == 8 && testMove.x < 0){
				canMoveLeft = false;
			}
		}
		if(botLeftH.collider != null){
			if(botLeftH.collider.gameObject.layer == 8 && testMove.x < 0){
				canMoveLeft = false;
			}
		}

		//haut
		if(topLeftV.collider != null){
			if(topLeftV.collider.gameObject.layer == 8 && testMove.y > 0){
				canMoveTop = false;
			}
		}
		if(topRightV.collider != null){
			if(topRightV.collider.gameObject.layer == 8 && testMove.y > 0){
				canMoveTop = false;
			}
		}

		//bas
		if(botLeftV.collider != null){
			if(botLeftV.collider.gameObject.layer == 8 && testMove.y < 0){
				canMoveBot = false;
			}
		}
		if(botRightV.collider != null){
			if(botRightV.collider.gameObject.layer == 8 && testMove.y < 0){
				canMoveBot = false;
			}
		}

		//Mouvement
		if(!canMoveRight || !canMoveLeft){
			testMove.x = 0;
		}
		if(!canMoveTop || !canMoveBot){
			testMove.y = 0;
		}

		rb2D.MovePosition(rb2D.position + testMove * Time.fixedDeltaTime * moveSpeed);
	}
}

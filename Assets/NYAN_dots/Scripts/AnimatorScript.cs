using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
	public int walkSpd = 5;
	public int runSpd = 10;
	public float spd = 0f;
	Rigidbody2D rb2;
	public Animator amt;
	Direction dir;
	CatParameters cat;

	void Start()
	{
		rb2 = GetComponent<Rigidbody2D>();
		amt = GetComponent<Animator>();
		dir = GetComponent<Direction>();
		cat = GetComponent<CatParameters>();
	}

	void Update()
	{
		//移動処理(Movement processing)

		//移動キー	※押してる間
		/*float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		bool inputSpc = Input.GetButton("Fire3");*/

		//速度を追加
		//rb2.velocity = new Vector2(spd * inputX, spd * inputY);


		//アニメ処理(Animation processing)

		//待機
		//PlayAnim(dir.GetAngle(cat._foodArea.transform), true);
			
		/*if (inputX == 0 && inputY == 0)
		{
			amt.SetBool("walk", false);
			amt.SetBool("run", false);
		}
		else
		{   //入力をアニメに伝える
			amt.SetFloat("dirX", inputX);
			amt.SetFloat("dirY", inputY);

			//歩行
			amt.SetBool("walk", true);
			amt.SetBool("run", false);
			spd = walkSpd;

			//走行
			if (inputSpc)
			{
				amt.SetBool("run", true);
				amt.SetBool("walk", false);
				spd = runSpd;
			}
		}*/
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{
		amt.SetTrigger("blink");
	}*/

	public void PlayWalkAnim(float dir)
    {
			
		amt.SetBool("walk", true);
		//amt.SetBool("run", play);
			
			
		if (dir > 20 && dir < 70)
		{
			amt.SetFloat("dirX", 1);
			amt.SetFloat("dirY", 1);
		}
		else if (dir < 20 && dir > -20)
		{
			amt.SetFloat("dirX", 1);
			amt.SetFloat("dirY", 0);
		}
		else if (dir < 110 && dir > 70)
		{
			amt.SetFloat("dirX", 0);
			amt.SetFloat("dirY", 1);
		}		
        else if (dir < 160 && dir > 110)
        {
            amt.SetFloat("dirX", -1);
            amt.SetFloat("dirY", 1);
        }
        else if (dir < -110 && dir > -160)
        {
            amt.SetFloat("dirX", -1);
            amt.SetFloat("dirY", -1);
        }
        else if (dir < -20 && dir > -70)
		{			
			amt.SetFloat("dirX", 1);
			amt.SetFloat("dirY", -1);
		}
        else if (dir < -70 && dir > -120)
        {
			amt.SetFloat("dirX", 0);
            amt.SetFloat("dirY", -1);
        }
        else
        {
            amt.SetFloat("dirX", -1);
            amt.SetFloat("dirY", 0);
        }
    }
		
	public void StopWalkAnim(bool stop)
	{
		amt.SetBool("walk", stop);
	}

	public void DefaultAnim()
    {
		amt.SetTrigger("blink");
    }	
}


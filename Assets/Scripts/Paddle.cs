using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	
	private Ball ball;
	//float mousePosInBlocks;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		//print (Input.mousePosition);
		//print (Input.mousePosition/Screen.width);	//fraction of screen
		
		//Vector3 paddlePos = new Vector3(Mathf.Clamp(.5f,0f,16f), this.transform.position.y, 0f);
		
		if (!autoPlay)
			MoveWithMouse();
		else
		{
			AutoPlay();
		}
	}
	
	void MoveWithMouse()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x/Screen.width *16;
		//print (mousePosInBlocks);	//how many game units
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		
		paddlePos.x = Mathf.Clamp(ballPos.x,0.5f,15.5f);
		this.transform.position = paddlePos;

	}
}

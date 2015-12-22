using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool isGameStarted = false;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector.y);	//difference in distance from ball to paddle
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameStarted)
		{
			//lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//wait for the mouse press to launch ball
			if(Input.GetMouseButtonDown(0))
			{
				print ("Mouse is clicked. Launch ball!");
				isGameStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f,10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 tweak = new Vector2(Random.Range(0f, .2f), Random.Range(0f, .2f));
		if (isGameStarted)
		{
			audio.Play();
			rigidbody2D.velocity += tweak;	
		}
	}
}

using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;
	//private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		if(isBreakable)
		{
			breakableCount++;
			print (breakableCount);
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(crack, transform.position, .8f);
		if (isBreakable)
		{
			HandleHits();
			
		}	
	}
	
	void HandleHits()
	{
		print("Collision");
		timesHit++;
		print (timesHit);
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits)
		{
			breakableCount--;
			print (breakableCount);
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		}
		else
		{
			LoadSprites();
		}
		//SimulateWin();
	}
	
	void PuffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke,gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null)
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
			Debug.LogError("Brick Sprite Missing");
	}
	
	//TODO Remove this method once we can actually win!
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}
	
	
}

using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			print ("Duplicate music player destroyed.");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

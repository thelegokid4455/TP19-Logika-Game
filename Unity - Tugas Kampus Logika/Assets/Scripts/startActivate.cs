using UnityEngine;
using System.Collections;

public class startActivate : MonoBehaviour 
{

	public GameObject obj;
	public AudioClip clickAudio;
	public bool  destroyThis;
	public float waitTime;
	private float curTimer;
	
	void Start ()
	{
		if(!obj)
			obj = gameObject;
		obj.active = false;

		curTimer = waitTime;
	}
	
	void Update ()
	{
		curTimer -= Time.deltaTime *1;
		if(curTimer <= 0)
		{
			doObj();
		}
	}
	
	void  doObj (){
        if(obj)
		obj.active = true;
		
		if(clickAudio)
			gameObject.GetComponent<AudioSource>().PlayOneShot(clickAudio);
		
		if(destroyThis)
			Destroy(gameObject);
	}
}
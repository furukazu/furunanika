using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour {

	public string PooledObjectId{get;set;}

	public UnityEngine.Events.UnityEvent ObjectWillBePooled;

	public UnityEngine.Events.UnityEvent ObjectWillBeRecycled;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WillBePooled ()
	{
		ObjectWillBePooled.Invoke();
	}

	public void WillBeRecycled ()
	{
		ObjectWillBeRecycled.Invoke();
	}
}

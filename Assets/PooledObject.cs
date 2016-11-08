using UnityEngine;
using System.Collections.Generic;

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

public class CrossList<T> {

	private List<T> entries;

	public CrossList(){
		entries = new List<T>();
	}

	public void Add(T entry){
		entries.Add(entry);
	}

	public void Remove(T entry){
		entries.Remove(entry);
	}

	public void ForEachCross(System.Func<T,T,bool> f){
		for(var a=0;a<entries.Count;++a){
			for(var b=a+1;b<entries.Count;++b){
				var res = f(entries[a],entries[b]);
				if(res){
					goto nextA;
				}
			}
			nextA:;
		}
	}
}
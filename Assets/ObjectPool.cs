using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	private Dictionary<string,Stack<PooledObject>> pool;

	void Awake(){
		pool = new Dictionary<string, Stack<PooledObject>>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Pool(PooledObject po){
		string id = po.PooledObjectId;

		po.WillBePooled();

		po.gameObject.SetActive(false);

		if(!pool.ContainsKey(id)){
			pool[id] = new Stack<PooledObject>();
		}
		pool[id].Push(po);
	}

	public GameObject Recycle(string id,GameObject prefab){
		if(!pool.ContainsKey(id)){
			pool[id] = new Stack<PooledObject>();
		}

		if(pool[id].Count == 0){
			var tmp = GameObject.Instantiate(prefab);
			tmp.GetComponent<PooledObject>().PooledObjectId = id;
			return tmp;
		}

		var ret = pool[id].Pop();

		ret.gameObject.SetActive(true);

		ret.WillBeRecycled();
	
		return ret.gameObject;
	}
}

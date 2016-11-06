using UnityEngine;
using System.Collections;

public class CountDownChara : MonoBehaviour {

	public GameObject SingleCharPrefab;


	public TextMesh Target;

	private static string [] dic = new string []{
		"0","1","2","3","4",
		"5","6","7","8","9","10"
	};

	void Awake(){
		
	}

	public System.DateTime OnCreatedTime;

	// Use this for initialization
	void Start () {
		OnCreatedTime = System.DateTime.UtcNow;
	}
	
	// Update is called once per frame
	void Update () {
		var left = 10 - (System.DateTime.UtcNow - OnCreatedTime).Seconds;
		if(left>=0){
			Target.text = dic[left];
		}else if(left<0){
			Destroy(this.gameObject);
			for(var i = 0 ; i<10;++i){
				var newChar = GameObject.Instantiate(SingleCharPrefab);
				var pos = this.transform.position;
				pos.z = 0;
				newChar.transform.position = pos;
				newChar.GetComponent<SingleChara>().SetText("A");
			}
		}
	}
}

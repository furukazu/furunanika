using UnityEngine;
using System.Collections;

public class CountDownChara : MonoBehaviour {

	public void SetScene (MasterScene masterScene)
	{
		theScene = masterScene;
	}

	public GameObject SingleCharPrefab;

	private MasterScene theScene;

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
				var newChar = theScene.ThePool.Recycle("SingleCharPrefab",SingleCharPrefab);
				var pos = this.transform.position;
				pos.z = 0;
				newChar.transform.position = pos;
				var sc = newChar.GetComponent<SingleChara>();
				sc.SetScene(theScene);
				sc.SetText("A");
				theScene.AddSingleChara(sc);
			}
		}
	}
}

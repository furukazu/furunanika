using UnityEngine;
using System.Collections;

public class SingleChara : MonoBehaviour {

	private MasterScene theScene;

	public PooledObject ThisPooled;

	public Collider2D ThisCollider;

	public void SetScene (MasterScene s)
	{
		theScene = s;
	}

	public TextMesh Target;

	private Vector3 speed;

	public void Created(){
		//theScene.AddSingleChara(this);
	}

	public void Removed(){
		theScene.RemoveSingleChara(this);
	}

	void Awake(){
		var vel = Random.value * 8.0f + 1.0f;
		speed = Quaternion.Euler(0,0,Random.value*360) * (vel*(Vector3.up/128.0f)) ;
		//print(speed);
	}



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var vp = Camera.main.WorldToViewportPoint(this.transform.position);
		if(vp.x<0 || vp.y<0 || vp.x>1 || vp.y > 1){
			theScene.ThePool.Pool(ThisPooled);
			return;
		}

	}

	void FixedUpdate(){
		this.transform.Translate(speed);
	}

	public void SetText (string a)
	{
		Target.text = a;
	}

	public void SetText (char c)
	{
		Target.text = c.ToString();
	}

}

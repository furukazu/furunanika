using UnityEngine;
using System.Collections;

public class SingleChara : MonoBehaviour {

	public TextMesh Target;

	private Vector3 speed;

	void Awake(){
		var vel = Random.value * 8.0f + 1.0f;
		speed = Quaternion.Euler(0,0,Random.value*360) * (vel*(Vector3.up/128.0f)) ;
		print(speed);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var vp = Camera.main.WorldToViewportPoint(this.transform.position);
		if(vp.x<0 || vp.y<0 || vp.x>1 || vp.y > 1){
			Destroy(this.gameObject);
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
}

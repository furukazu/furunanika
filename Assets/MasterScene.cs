using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterScene : MonoBehaviour {

	public GameObject SingleCharPrefab;

	private Dictionary<KeyCode,string> allKeys;

	void Awake(){
		allKeys = new Dictionary<KeyCode, string>();

		allKeys[KeyCode.A] = "A";
		allKeys[KeyCode.B] = "B";
		allKeys[KeyCode.C] = "C";
		allKeys[KeyCode.D] = "C";
		allKeys[KeyCode.E] = "E";
		allKeys[KeyCode.F] = "F";
		allKeys[KeyCode.G] = "G";
		allKeys[KeyCode.H] = "H";
		allKeys[KeyCode.I] = "I";
		allKeys[KeyCode.J] = "J";
		allKeys[KeyCode.K] = "K";
		allKeys[KeyCode.L] = "L";
		allKeys[KeyCode.M] = "M";
		allKeys[KeyCode.N] = "N";
		allKeys[KeyCode.O] = "O";
		allKeys[KeyCode.P] = "P";
		allKeys[KeyCode.Q] = "Q";
		allKeys[KeyCode.R] = "R";
		allKeys[KeyCode.S] = "S";
		allKeys[KeyCode.T] = "T";
		allKeys[KeyCode.U] = "U";
		allKeys[KeyCode.V] = "V";
		allKeys[KeyCode.W] = "W";
		allKeys[KeyCode.X] = "X";
		allKeys[KeyCode.Y] = "Y";
		allKeys[KeyCode.Z] = "Z";

	}

	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
	
		foreach(var kv in allKeys){
			if(Input.GetKeyDown(kv.Key)){
				var newChar = GameObject.Instantiate(SingleCharPrefab);
				newChar.transform.localPosition = Vector3.zero;
				newChar.GetComponent<SingleChara>().SetText(kv.Value);
			}
		}



	}
}

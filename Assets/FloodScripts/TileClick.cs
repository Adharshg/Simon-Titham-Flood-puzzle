using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClick : MonoBehaviour {

	GamePlayScript MainScript;
	public GameObject GameManager;

	void Start () {
		MainScript = GameManager.GetComponent<GamePlayScript>();
	}
	
	private void OnMouseDown () {
		MainScript.Action(this.gameObject);
	}
}

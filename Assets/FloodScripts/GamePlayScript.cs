using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour {

	gridSpawner GridScript;
	public GameObject GridManager;
	public List<GameObject> tiles;
	public List<GameObject> touched;
	public int moves = 0;
	public Text MoveText;
	private int length = 1;
	public GameObject WinText;

	// Use this for initialization
	void Awake () {
		GridScript = GridManager.GetComponent<gridSpawner>();
		tiles = GridScript.children;
		touched.Add(tiles[0]);
		WinText.SetActive(false);
	}
	
	public void Action (GameObject obj) {
		foreach (GameObject tile in touched){
			tile.GetComponent<Renderer>().material.color = obj.GetComponent<Renderer>().material.color;
			

		}
		moves += 1;
		MoveText.text = "Moves: " + moves.ToString();

	}

	public void AddToTouched(GameObject obj){
		if (touched.Contains(obj) == false){
			//obj.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			touched.Add(obj);
			length += 1;
		}
		if (length > 143){
			Time.timeScale = 0f;
			WinText.SetActive(true);
		}
	}

	public void jsfunc(){
		WinText.SetActive(true);
	}

	
}

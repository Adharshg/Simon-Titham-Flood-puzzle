using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject tile;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void AddColor(Button btn){
		tile.GetComponent<Renderer>().material.color = btn.GetComponent<Image>().color;
	}
	
}

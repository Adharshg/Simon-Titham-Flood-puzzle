using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSpawner : MonoBehaviour {
	public Color[] TileColor;
	public List<GameObject> children = new List<GameObject>();
	void Awake () {
		foreach(Transform t in transform){
			children.Add(t.gameObject);
		}
		for (int i = 0; i < 144; i++){

			children[i].GetComponent<Renderer>().material.color = TileColor[Random.Range(0, TileColor.Length)];
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSpawner : MonoBehaviour {

	public GameObject BoardUnitPrefab;

	// Use this for initialization
	void Start () {
		for (float i = -4.5f; i <= 4.5f; i++){
			for (float j = -4.5f; j <= 4.5f; j++){
				Debug.Log(i + " : " + j);
				 GameObject tmp = GameObject.Instantiate(BoardUnitPrefab, new Vector3(i,j, 0), this.gameObject.transform.rotation) as GameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}

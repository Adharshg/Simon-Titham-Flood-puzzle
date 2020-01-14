using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridChildrenAdder : MonoBehaviour {

	List<GameObject> children = new List<GameObject>();

	// Use this for initialization
	void Start () {
		foreach(Transform t in transform){
			children.Add(t.gameObject);
		}

	}
}

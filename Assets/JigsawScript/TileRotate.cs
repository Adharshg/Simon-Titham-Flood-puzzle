using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRotate : MonoBehaviour {

	
	// Update is called once per frame
	private void OnMouseDown () {
		transform.Rotate(0f, 0f, 90f);
	}
}

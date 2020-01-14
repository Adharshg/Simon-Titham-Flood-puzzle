using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSpawner : MonoBehaviour {

	public Color[] options;
	private int index;
	private List<Color> question = new List<Color>();
	private List<GameObject> answer = new List<GameObject>();
	public GameObject Row;
	public float MoveUnits = 3.0f;

	void Start () {
		for (int i = 0; i < 4; i ++){ //question gets made at the starting of each game
			question.Add(options[Random.Range(0, options.Length)]);
		}
		Spawn();
	}

	void Spawn(){
		transform.position = new Vector3(transform.position.x, transform.position.y + MoveUnits, transform.position.z);
		GameObject row = Instantiate(Row, transform.position, Quaternion.identity);
		answer.Add(row);
		
	}

}

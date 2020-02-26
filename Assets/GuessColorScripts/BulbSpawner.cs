using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbSpawner : MonoBehaviour {

	public GameObject Rowspawner;
	public GameObject Bulbs;
	public float MoveUnits = 2.0f;
	public float Displace = 3.0f;
	GameManager MainScript;
	public GameObject GameManager;

	void Start () {
		MainScript = GameManager.GetComponent<GameManager>();
		transform.position = new Vector3(Rowspawner.transform.position.x - Displace, Rowspawner.transform.position.y, Rowspawner.transform.position.z);
	}
	
	public void BulbSpawn(int green, int red){
		transform.position = new Vector3(Rowspawner.transform.position.x - Displace, Rowspawner.transform.position.y, Rowspawner.transform.position.z);
		GameObject bulbs = Instantiate(Bulbs, transform.position, Quaternion.identity);
		for (int i = 0; i < MainScript.NumberOfObjects; i++){
			if (green > 0){
				bulbs.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.green;
				green -= 1;
			}
			else if (red > 0){
				bulbs.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.red;
				red -= 1;
			}
			else {
				bulbs.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.black;
			}
		}
	}
}

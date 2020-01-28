using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RowSpawner : MonoBehaviour {

	private List<Color> options = new List<Color>();
	public GameObject Mask;
	public GameObject Buttons;
	private int SpawnCount = 0;
	public int MaxSpawn = 9;
	private int index;
	public List<Color> question = new List<Color>();
	public GameObject Row;
	public GameObject QuestionRow;
	public float MoveUnits = 3.0f;
	GameManager MainScript;
	public GameObject GameManager;

	void Awake () {
		foreach (Transform T in Buttons.transform){
			options.Add(T.GetComponent<Image>().color);
		}
	}

	void Start () {

		MainScript = GameManager.GetComponent<GameManager>();

		for (int i = 0; i < 4; i ++){ // question gets made at the starting of each game
			index = Random.Range(0, options.Count);
			question.Add(options[index]);
			options.RemoveAt(index); // to prevent repetition of colors in the question
		}

		int j = 0;
		foreach(Transform t in QuestionRow.transform){ // displaying question on the screen
			t.GetComponent<Renderer>().material.color = question[j];
			j += 1;
		}

		Spawn(); // first row to be spawned
	}

	public void Spawn(){

		if (SpawnCount < MaxSpawn){ // to restrict number of tries. MaxSpawn can be changed if necessary
			transform.position = new Vector3(transform.position.x, transform.position.y + MoveUnits, transform.position.z); // moving the spawner MoveUnits downwards
			GameObject row = Instantiate(Row, transform.position, Quaternion.identity); // placing trials one below another
			foreach(Transform t in row.transform){
				MainScript.answer.Add(t.gameObject);
			}
			SpawnCount += 1;
		}

		else{
			GameLose();
		}

	}

	public void GameLose(){
		Debug.Log("Done");
	}

	public void GameWin(){
		Mask.SetActive(false);
		Debug.Log("Win");
	}

}



/*
Colors used:
FD2020
EDFA30
347FF3
AD3FAB
FF7A31
3C8E3E
*/
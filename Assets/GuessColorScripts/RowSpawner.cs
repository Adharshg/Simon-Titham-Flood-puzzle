using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RowSpawner : MonoBehaviour {

	private List<Color> options = new List<Color>();
	public GameObject Mask;
	public GameObject WinText;
	public GameObject LoseText;
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
	Animator anim;

	void Awake () {
		Mask.SetActive(true);
		WinText.SetActive(false);
		LoseText.SetActive(false);
		foreach (Transform T in Buttons.transform){
			options.Add(T.GetComponent<Image>().color);
		}
	}

	void Start () {
		anim = Mask.GetComponent<Animator>();
		MainScript = GameManager.GetComponent<GameManager>();

		for (int i = 0; i < MainScript.NumberOfObjects; i ++){ // question gets made at the starting of each game
			index = Random.Range(0, options.Count);
			question.Add(options[index]);
			options.RemoveAt(index); // to prevent repetition of colors in the question
		}

		int j = 0;
		foreach(Transform t in QuestionRow.transform){ // displaying question on the screen
			t.GetComponent<Renderer>().material.color = question[j]; // making sure the colors used in the question are the same ones in the options
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
		anim.SetBool("Done", true);
		LoseText.SetActive(true);
	}

	public void GameWin(){
		anim.SetBool("Done", true);
		WinText.SetActive(true);
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
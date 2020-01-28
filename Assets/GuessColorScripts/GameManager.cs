using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int i = 0;
	public List<GameObject> answer = new List<GameObject>();
	public List<Color> tempquestion = new List<Color>();
	RowSpawner SpawnerScript; // ScriptName anyname
	BulbSpawner ResultScript;
	public GameObject RowSpawner; // Object which the script is a part of
	public GameObject BulbSpawner;
	private int pos;
	public GameObject dumbo;

	void Start () {
		SpawnerScript = RowSpawner.GetComponent<RowSpawner>(); // using object to access script
		ResultScript = BulbSpawner.GetComponent<BulbSpawner>();
	}

	public void AddColor(Button btn){
		if (i < 3){
			answer[i].GetComponent<Renderer>().material.color = btn.GetComponent<Image>().color; // coloring the first three tiles
			i += 1; // increasing tile index
		}
		else{
			answer[3].GetComponent<Renderer>().material.color = btn.GetComponent<Image>().color; // coloring the 4th tile on every try
			i = 0; // resetting tile index for next round
			check();
		}
	}

	public void check(){
		int white = 0;
		int black = 0;
		tempquestion.Clear();
		foreach (Color c in SpawnerScript.question){
			tempquestion.Add(c);
		}
		for (int j = 0; j < 4; j++){ // for traversing the answer array
			if (tempquestion.Contains(answer[j].GetComponent<Renderer>().material.color)){
				pos = tempquestion.IndexOf(answer[j].GetComponent<Renderer>().material.color);
				if (pos == j){
					black += 1;
				}
				else{
					white += 1;
				}
				tempquestion[pos] = dumbo.GetComponent<Renderer>().material.color;
			}
		}
		Debug.Log("Black: " + black + "  white: " + white);
		ResultScript.BulbSpawn(black, white);
		if (black != 4){
			answer = new List<GameObject>();
			SpawnerScript.Spawn();
		}
		else{
			SpawnerScript.GameWin();
		}
	}
	
}

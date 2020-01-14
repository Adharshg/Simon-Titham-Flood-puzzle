using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    void Start() {
        Hello();
        Debug.Log("Yo"); 
        Debug.Log("OH " + AddNumbers(5, 7));
    }
}
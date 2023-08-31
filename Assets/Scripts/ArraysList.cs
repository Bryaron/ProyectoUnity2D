using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraysList : MonoBehaviour {

    public int[] numbers = new int[2];
    public int[] count;

    public List<string> names = new List<string>();
    private void Start() {
        foreach (int item in count) {
            Debug.Log(item);
        }

        names.Add("Pablo");
        names.Add("Pedro");
        names.Add("Anita");
        names.Remove("Pedro");

        foreach (string item in names) {
            Debug.Log(item);
        }
    }
}


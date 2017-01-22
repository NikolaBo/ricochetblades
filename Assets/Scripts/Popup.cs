using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

    public KeyCode key;
    public GameObject popup;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key)) {
            popup.SetActive(true);
        }
        if (Input.GetKeyUp(key)) {
            popup.SetActive(false);
        }
	}
}

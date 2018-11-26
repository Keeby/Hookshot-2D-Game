using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenu : MonoBehaviour {

    public string menuGameScene;

    // Use this for initialization
    void Start () {
        StartCoroutine(End());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator End()
    {
        yield return new WaitForSeconds(21);
        SceneManager.LoadScene(menuGameScene);
    }
}

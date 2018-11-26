using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishscript : MonoBehaviour {

    public Sprite whiteFlag;
    public Sprite blueFlag;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool endReached = false;
    public string endGameScene;

    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Player").SendMessage("finish");
        if (other.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = blueFlag;
            endReached = true;
            if(endReached == true)
            {
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(endGameScene);
    }


}

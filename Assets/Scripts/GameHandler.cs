using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

	public int live = 3, bricks = 24;
	public float resetDelay = 1f;
	public Text liveText;
	public GameObject gameOver, youWon, bricksPrefabs, paddle, deathParticle;
	public static GameHandler instance = null;
	private GameObject clonePaddle;
	// Use this for initialization
	void Start () {
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
		Setup();
	}
	public void Setup(){
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefabs, bricksPrefabs.transform.position, Quaternion.identity);
	}
	void CheckGameOver(){
		if(bricks<1){
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}
		if(live <1){
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}
	}
	void Reset(){
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void LoseLife(){
		live --;
		liveText.text = "Live = "+ live;
		Instantiate(deathParticle, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	void SetupPaddle(){
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	public void DestroyBrick(){
		bricks --;
		CheckGameOver();
	}

	// Update is called once per frame
	void Update () {
		
	}
}

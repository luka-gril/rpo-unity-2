using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelManager : MonoBehaviour {

	[SerializeField]
	private GameObject BotPrefab; 

	public static bool GAME_RUNNING; 
	public float playingTime = 0f;  

	private float BotSpawnTime = 2f;  
	private float BotTimer = 0f;  
	private float SpawnedBots = 0;  
	private int BotsNumber = 10;

	private GameObject[] mBotSpawnPoints;  

	[SerializeField]
	private Text StateText; 
	[SerializeField]
	private Text ResultText; 

	void OnEnable(){ 
		ResultText.text = string.Empty;
		StateText.text = string.Empty;
		mBotSpawnPoints = GameObject.FindGameObjectsWithTag ("BotSpawnPoint"); 
		GAME_RUNNING = true;  
	}

	void Update(){
		playingTime += Time.deltaTime; 
		BotTimer += Time.deltaTime; 
		if ((BotTimer >= BotSpawnTime) && SpawnedBots < BotsNumber) {  
			SpawnBot (); 
		}
		CheckWin (); 
	}

	private void SpawnBot(){
		int randomPosition = Random.Range (0, mBotSpawnPoints.Length);  
		Instantiate (BotPrefab, mBotSpawnPoints [randomPosition].transform.position, Quaternion.identity); 
		SpawnedBots++; 	
		BotTimer = 0f;  
	}

	public void CheckWin(){ 
		bool victoryCondition1 = GameObject.FindGameObjectsWithTag ("Bot").Length == 0; 
		bool victoryCondition2 = (SpawnedBots == BotsNumber); 
		if (victoryCondition1 && victoryCondition2) { 
			GameWon (); 
		}
	}

	public void PlayerKilled(){ 
		GameOver ();
	}

	private void GameOver(){
		if (GAME_RUNNING) {
			GAME_RUNNING = false;  
			StateText.text = "YOU LOST!"; 
			ResultText.text = string.Empty;
			WriteResultToTextFile (); 
			StartCoroutine (BackToMenu ());
		}
	}

	private void GameWon(){
		if (GAME_RUNNING) {
			GAME_RUNNING = false; 
			StateText.text = "YOU WON!"; 
			ResultText.text = "Result: " + playingTime.ToString ("n2"); 
			WriteResultToTextFile (); 
			StartCoroutine (BackToMenu ());
		}
	}

	private void WriteResultToTextFile(){
		string filePath = Application.dataPath + "/Results.txt";
		using (StreamWriter streamWriter = File.AppendText(filePath)) {
			streamWriter.WriteLine (playingTime.ToString("n2"));
		}	
	}

	private IEnumerator BackToMenu(){
		yield return new WaitForSeconds (3); 
		AsyncOperation async = SceneManager.LoadSceneAsync("Menu"); // naložimo meni in zapustimo trenutno sceno. Konec igre 
		while (!async.isDone) {
			yield return null;
		}
	}

}

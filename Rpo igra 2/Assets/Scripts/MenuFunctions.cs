using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

	[SerializeField]
	private GameObject MainMenu;
	[SerializeField]
	private GameObject SettingsMenu;

	[SerializeField]
	private Text QualityButtonLabel;
	[SerializeField]
	private Text SoundsButtonLabel;

	private string Quality = "LOW";
	private string Sound = "ON";

	private bool sceneLoading = false;

	void OnEnable(){
		MainMenu.SetActive (true);
		SettingsMenu.SetActive (false);
	}

	public void PlayClicked(){
		if (!sceneLoading) {
			sceneLoading = true;
			StartCoroutine (LoadScene ("Mapa"));
		}
	}

	public void SettingsClicked(){
		SettingsMenu.SetActive (true);
		MainMenu.SetActive (false);
	}
		
	public void BackFromSettings(){
		MainMenu.SetActive (true);
		SettingsMenu.SetActive (false);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ToggleQuality(){
		if (Quality.Equals ("LOW")) {
			Quality = "HIGH";
			QualityButtonLabel.text = "Quality: " + Quality;
		}else{
			Quality = "LOW";
			QualityButtonLabel.text = "Quality: " + Quality;
		}
	}

	public void ToggleSound(){
		if (Sound.Equals ("ON")) {
			Sound = "OFF";
			SoundsButtonLabel.text = "Sound: " + Sound;
		}else{
			Sound = "ON";
			SoundsButtonLabel.text = "Sound: " + Sound;
		}
	}
		
	private IEnumerator LoadScene(string sceneName){
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName); 
		while (!async.isDone) {
			yield return null;
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneReloader : MonoBehaviour
{
	private void Start() {
		Time.timeScale = 1;
	}
    public void ReloadScene(){
		 var sceneindex = SceneManager.GetActiveScene().buildIndex;
		 SceneManager.LoadScene(sceneindex);
	 }
}

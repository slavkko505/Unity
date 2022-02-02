using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{
   [SerializeField]int maxMoney = 150;
	[SerializeField]int currentCapital;
	[SerializeField] TextMeshProUGUI text;
	public int CurrentCapital{get{return currentCapital;}}

    void Start()
    {
		currentCapital = maxMoney;
		text.text = currentCapital.ToString();
    }


	public void WindrawMoney(int amount)
	{
		currentCapital -= amount;
		if(currentCapital < 0){
			ReloadGame();
		}
		UpdateTextUI();
	}

	public void DepositMoney(int amount)
	{
		currentCapital += amount;
		UpdateTextUI();
	}

	void ReloadGame(){
			var currentScene = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(currentScene);
	}
	void UpdateTextUI()
	{
		text.text = currentCapital.ToString();
	}
}

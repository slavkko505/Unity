using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
	 [SerializeField] int difficultyH = 1;
	 [SerializeField]int currentHealth  = 0;

	 Enemy enemy;


    void OnEnable()
    {
		currentHealth = maxHealth;
    }

	private void Start()
	{
		enemy = GetComponent<Enemy>();
	}
	private void OnParticleCollision(GameObject other) {
		currentHealth--;

		if (currentHealth <= 0)
		{
			gameObject.SetActive(false);
			maxHealth += difficultyH;
			enemy.RewaldCostEnemy();
		}
	}
}

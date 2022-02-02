using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnim : MonoBehaviour
{
	[SerializeField] float lockalAnimationSmoth =0.1f;
	Animator anim;
	NavMeshAgent agent;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
		  agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
		  anim.SetFloat("PlayerWalk", speedPercent, lockalAnimationSmoth, Time.deltaTime);
    }
}

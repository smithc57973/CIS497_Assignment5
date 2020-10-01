/*
* Chris Smith
* Assignment 5
* Controls gems
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;
    public UIManager uiManager;

	private float durationOfCollectedParticleSystem;

	void Start()
	{
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void GemCollected()
	{
        gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
        uiManager.score++;
        Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);
	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}

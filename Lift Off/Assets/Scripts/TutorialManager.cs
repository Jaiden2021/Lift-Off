using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

	public SpriteRenderer[] tutorialPanels;
	public MeteorSpawner spawner;

	public float arrowPanelTimer = 3;
	public float sloMoPanelTimer = 3;

	public bool arrowPanelShowed = false;
	public bool sloMoShowed = false;

	private void Awake(){
		spawner.enabled = false;
		for (int i = 0; i < tutorialPanels.Length; i++) {
			tutorialPanels [i].color = new Color (1, 1, 1, 0);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Show Arrow Tutorial Panel (fade in);
		if (tutorialPanels [0].color.a <= 1f && arrowPanelShowed == false) {
			tutorialPanels [0].color = new Color (tutorialPanels [0].color.r, 
				tutorialPanels [0].color.g, tutorialPanels [0].color.b, Mathf.Lerp (tutorialPanels [0].color.a, 1, 0.05f));
		}

		if(tutorialPanels [0].color.a > 0.9f){
			arrowPanelShowed = true;
		}

		if(arrowPanelShowed){
			arrowPanelTimer -= Time.deltaTime;
		}

		if(arrowPanelShowed && arrowPanelTimer <= 0){
			arrowPanelTimer = 0;
			tutorialPanels [0].color = new Color (tutorialPanels [0].color.r, 
				tutorialPanels [0].color.g, tutorialPanels [0].color.b, Mathf.Lerp (tutorialPanels [0].color.a, 0, 0.05f));
		}

		//Show SloMo Panel after Arrow Panel fade out;
		if(arrowPanelShowed && tutorialPanels [0].color.a <= 0.05f && sloMoShowed == false){
			tutorialPanels [1].color = new Color (tutorialPanels [1].color.r, 
				tutorialPanels [1].color.g, tutorialPanels [1].color.b, Mathf.Lerp (tutorialPanels [1].color.a, 1, 0.05f));
		}

		if(tutorialPanels [1].color.a > 0.9f){
			sloMoShowed = true;
		}

		if(sloMoShowed){
			sloMoPanelTimer -= Time.deltaTime;
		}

		//Slow Motion Panel showed, 3s later, fade it out;
		if(sloMoShowed && sloMoPanelTimer <= 0){
			sloMoPanelTimer = 0;
			tutorialPanels [1].color = new Color (tutorialPanels [1].color.r, 
				tutorialPanels [1].color.g, tutorialPanels [1].color.b, Mathf.Lerp (tutorialPanels [1].color.a, 0, 0.05f));
		}

		if(sloMoShowed && tutorialPanels[1].color.a <= 0.05f){
			spawner.enabled = true;
		}
		
	}
}

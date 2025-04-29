using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SampleManager : MonoBehaviour {
	List<Animator> animatorList = new List<Animator>();
	Animator currentAnimator;
	int currentIndex = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < this.transform.childCount; i++) {
			GameObject obj = this.transform.GetChild(i).gameObject;
			Animator animator = obj.GetComponentInChildren<Animator>();
			this.animatorList.Add(animator);
			obj.SetActive(false);
		}

		if(animatorList.Count >= 1){
			currentAnimator = animatorList[0];
			GameObject obj = currentAnimator.transform.parent.gameObject;
			obj.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentAnimator != null) {
			AnimatorStateInfo info = currentAnimator.GetCurrentAnimatorStateInfo (0);
			if (info.normalizedTime >= 1) {
				currentIndex++;
				if(currentIndex == animatorList.Count){
					currentAnimator = null;				
				}else{
					currentAnimator.transform.parent.gameObject.SetActive(false);
					currentAnimator = animatorList[currentIndex];
					currentAnimator.transform.parent.gameObject.SetActive(true);
				}
			}
		}
	}

}

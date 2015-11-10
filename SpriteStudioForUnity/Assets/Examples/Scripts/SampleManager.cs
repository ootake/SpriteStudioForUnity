using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SampleManager : MonoBehaviour {
	public enum ShowType {
		Enumeration,
		Queue,
	}
	public ShowType showType = ShowType.Enumeration;
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


		switch (showType) {
		case ShowType.Enumeration: {
			for(int i = 0; i < animatorList.Count; i++){
				GameObject obj = animatorList[i].transform.parent.gameObject;
				obj.SetActive(true);
				float x = -20 + (i / 5) * 5;
				float y = 10 - (i % 5) * 5;
				Vector3 pos = new Vector3(x, y, i);
				obj.transform.localPosition = pos;
			}
			break;
		}
		case ShowType.Queue: {
			if(animatorList.Count >= 1){
				currentAnimator = animatorList[0];
				GameObject obj = currentAnimator.transform.parent.gameObject;
				obj.SetActive(true);
			}
			break;
		}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (showType == ShowType.Queue) {
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

}

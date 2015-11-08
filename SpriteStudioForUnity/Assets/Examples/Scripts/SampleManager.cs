using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SampleManager : MonoBehaviour {
	public enum ShowType {
		Enumeration,
		Queue,
	}
	public ShowType showType = ShowType.Enumeration;
	public List<GameObject> prefabList;
	Animator currentAnimator;
	int currentIndex = 0;

	// Use this for initialization
	void Start () {
		switch (showType) {
		case ShowType.Enumeration: {
			for(int i = 0; i < prefabList.Count; i++){
				GameObject obj = GameObject.Instantiate(prefabList[i]);
				float x = -20 + (i / 5) * 5;
				float y = 10 - (i % 5) * 5;
				Vector3 pos = new Vector3(x, y, i);
				obj.transform.localPosition = pos;
			}
			break;
		}
		case ShowType.Queue: {
			if(prefabList.Count >= 1){
				GameObject obj = GameObject.Instantiate(prefabList[0]);
				currentAnimator = obj.GetComponent<Animator>();
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
					if(currentIndex == prefabList.Count){
						currentAnimator = null;				
					}else{
						GameObject.Destroy(currentAnimator.gameObject);
						GameObject obj = GameObject.Instantiate(prefabList[currentIndex]);
						currentAnimator = obj.GetComponent<Animator>();					
					}
				}
			}
		}
	}

}

using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

using System.Collections;

public class SampleEditor {

	[MenuItem("Assets/Set state queue")]
	public static void StateLoop() {
		foreach (Object o in Selection.objects) {
			if(o.GetType() == typeof(GameObject)){
				GameObject obj = o as GameObject;
				Animator animator = obj.GetComponent<Animator>();
				if(animator != null) {
					AnimatorController animatorController = (AnimatorController)animator.runtimeAnimatorController;

					foreach(ChildAnimatorState childAnimatorState in animatorController.layers[0].stateMachine.states){
						foreach(AnimatorStateTransition transition in childAnimatorState.state.transitions){
							childAnimatorState.state.RemoveTransition(transition);
						}
					}

					AnimatorState defaultState = animatorController.layers[0].stateMachine.defaultState;
					AnimatorState currentStete = defaultState;
					foreach(ChildAnimatorState childAnimatorState in animatorController.layers[0].stateMachine.states){
						if(currentStete == childAnimatorState.state)
							continue;

						AnimatorStateTransition transition = currentStete.AddTransition(childAnimatorState.state);
						transition.hasExitTime = true;
						transition.offset = 0;
						transition.duration = 0;
						transition.exitTime = 1;
						currentStete = childAnimatorState.state;
					}
				}
			}
		}

	}
}

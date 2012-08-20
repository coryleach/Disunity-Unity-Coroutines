using System;
using System.Collections;
using System.Collections.Generic;

namespace Disunity
{
	public class Behavior : Component
	{

		public bool enabled { get; set; }
		public bool started { get; set; }
		private List<Coroutine> coroutines;

		public Behavior()
		{

			coroutines = new List<Coroutine>();

			if ( HasMethod( "Awake" ) ) {
				Invoke( "Awake" );
			}

			BehaviorManager.SharedInstance().AddBehavior(this);
			this.started = false;
			this.enabled = true;

		}

		~Behavior() {
		}

		public void Destroy() {
			//Remove from the behavior manager effectively killing this behavior
			BehaviorManager.SharedInstance().RemoveBehavior(this);
		}

		//This should only be called by Behavior Manager
		public void UpdateInternal()
		{

			if ( !enabled ) {
				return;
			}

			if ( !this.started ) {

				this.started = true;

				//Call the start method if it hasn't been called yet
				if ( HasMethod( "Start" ) ) {

					System.Reflection.MethodInfo method = GetType().GetMethod("Start");
					//If return type is enumerator start a coroutine
					if ( method.ReturnType.IsSubclassOf(typeof(IEnumerator)) ) {
						StartCoroutine((IEnumerator)method.Invoke(this, null));
					} else {
						method.Invoke(this, null);
					}

				}

			} else  {
				//Update Every Frame
				Update();
			}

			//Run Coroutines
			for ( int i = coroutines.Count-1; i >= 0; i-- ) {
			
				Coroutine coroutine = coroutines[i];
				//Run Coroutine & Remove if it is finished
				if ( !coroutine.MoveNext() ) {
					coroutines.RemoveAt(i);
				}

			}

		}

		public virtual void Update() {
		}

		public Coroutine StartCoroutine(IEnumerator routine) 
		{
			Coroutine newCoroutine = new Coroutine(routine,this);
			coroutines.Add(newCoroutine);
			return newCoroutine;
		}

		public void StopAllCoroutines() {
			//Clear list of coroutines
			coroutines.Clear();
		}

		public void Invoke(string methodName)
		{
		
			System.Reflection.MethodInfo method = GetType().GetMethod(methodName);

			if (method != null) {

				method.Invoke(this, null);

			} else {
				//Error
			}

		}

		public bool HasMethod(string methodName) {
		
			System.Reflection.MethodInfo method = GetType().GetMethod(methodName);

			if (method != null) {
				return true;
			} else {
				return false;
			}

		}



	}
}


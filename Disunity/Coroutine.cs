using System;
using System.Collections;

namespace Disunity
{
	public class Coroutine : YieldInstruction
	{

		private IEnumerator _routine;
		private bool _running;
		private Behavior _parent;
		private bool _started;

		public Coroutine(IEnumerator routine, Behavior parent)
		{
			_routine = routine;
			_parent = parent;
			_started = false;

			if ( _routine != null ) 
			{
				_running = true;
			} 
			else 
			{
				_running = false;
			}

		}

		public override object Current {
			get {

				if ( !_running ) 
				{
					return null;
				}
				else 
				{
					return _routine.Current;
				}

			}
		}

		public Behavior Parent {
			get {
				return _parent;
			}
		}

		public bool IsRunning {
			get {
				return _running;
			}
		}

		public override void Reset() 
		{
			_routine.Reset();
		}

		public override bool MoveNext()
		{

			if ( !_started ) {
				_started = true;
				return _routine.MoveNext();
			}

			//Check for a coroutine/yield instruction in our coroutine
			if ( _routine.Current != null ) 
			{
			
				if ( _routine.Current.GetType().IsSubclassOf(typeof(Coroutine)) ) {

					Coroutine coroutine = (Coroutine)_routine.Current;

					//Coroutines run inside the behavior
					//If coroutine is still running then just return for now
					if ( coroutine._running ) {
						return true;
					}

				} else if ( _routine.Current.GetType().IsSubclassOf(typeof(YieldInstruction)) ) {

					//Run the yield instruction
					YieldInstruction instruction = (YieldInstruction)_routine.Current;

					if ( instruction.MoveNext() ) {
						return true;
					}

				}

			}

			//Try to move to next
			if ( _routine.MoveNext() ) 
			{
				return true;
			}
			else 
			{
				_running = false;
				return false;
			}
		
		}

	}
}


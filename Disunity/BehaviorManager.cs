using System;
using System.Collections;
using System.Collections.Generic;

namespace Disunity
{
	public class BehaviorManager
	{

		private List<Behavior> behaviors;
		private static BehaviorManager sharedInstance;

		public static BehaviorManager SharedInstance()
		{
		
			if ( sharedInstance == null ) {
				sharedInstance = new BehaviorManager();
			}

			return sharedInstance;

		}

		protected BehaviorManager()
		{
			behaviors = new List<Behavior>();
		}

		public void AddBehavior( Behavior behavior )
		{
			behaviors.Add( behavior );
		}

		public void RemoveBehavior( Behavior behavior )
		{
			behaviors.Remove( behavior );
		}

		public void Update()
		{
			//Invoke the update method for each behavior with an update method
			foreach ( Behavior behavior in behaviors ) {
				behavior.UpdateInternal();
			}
		}


	}
}


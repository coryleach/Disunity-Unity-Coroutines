using System;
using System.Collections;

namespace Disunity
{
	public class WaitForSeconds : YieldInstruction
	{

		private System.DateTime _endTime;
		private float _duration;

		public WaitForSeconds(float duration)
		{
			_endTime = DateTime.Now.AddSeconds(duration);
			_duration = duration;
		}

		public override object Current 
		{
			get 
			{
				return null;
			}
		}

		public override bool MoveNext()
		{
			if ( _endTime.CompareTo( DateTime.Now ) == 1 ) {
				return true;
			} else {
				return false;
			}
		}

		public override void Reset() 
		{
			_endTime = DateTime.Now;
			_endTime.AddSeconds(_duration);
		}

	}
}


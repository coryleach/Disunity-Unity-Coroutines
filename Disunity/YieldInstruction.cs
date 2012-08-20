using System;
using System.Collections;

namespace Disunity
{

	public abstract class YieldInstruction : IEnumerator
	{

		//IEnumerator Interface
		public abstract bool MoveNext();
		public abstract void Reset();
		public abstract object Current {
			get;
		}

	}

}


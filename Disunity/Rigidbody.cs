using System;

namespace Disunity
{
	public class Rigidbody
	{

		public Vector3 velocity;
		public Vector3 angularVelocity;

		public float drag;
		public float angularDrag;

		public float mass;
		public bool useGravity;

		public Rigidbody()
		{
		}

	}
}


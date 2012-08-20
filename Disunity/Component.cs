using System;

namespace Disunity
{
	public class Component
	{

		private GameObject _gameObject;
		public GameObject gameObject {
			get {
				return _gameObject;
			}
			set {
				_gameObject = value;
			}
		}

		public Transform transform {
			get {
				if ( gameObject != null ) {
					return gameObject.transform;
				} else {
					return null;
				}
			}
		}

		public Rigidbody rigidbody {
			get {
				if ( gameObject != null ) {
					return gameObject.rigidbody;
				} else {
					return null;
				}
			}
		}

		public Collider collider {
			get {
				if ( gameObject != null ) {
					return gameObject.collider;
				} else {
					return null;
				}
			}
		}

		public override string ToString()
		{
			return string.Format("[Component:{0}]", this.GetType().ToString());
		}

	}
}


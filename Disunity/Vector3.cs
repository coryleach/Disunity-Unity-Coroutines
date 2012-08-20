using System;

namespace Disunity
{
	public struct Vector3
	{

		public float x, y ,z;

		public Vector3(float x, float y, float z) {
			this.x = x;
			this.y = y;
		 	this.z = z;
		}

		public static Vector3 zero {
			get {
				return new Vector3(0,0,0);
			}
		}

		public static Vector3 one {
			get {
				return new Vector3(1,1,1);
			}
		}

		public static Vector3 forward {
			get {
				return new Vector3(0,0,1);
			}
		}

		public static Vector3 up {
			get {
				return new Vector3(0,1,0);
			}
		}

		public static Vector3 right {
			get {
				return new Vector3(1,0,0);
			}
		}

		public static Vector3 Normalize(Vector3 v) {
			Vector3 normal;
			float magnitude = v.magnitude;
			normal.x = v.x / magnitude;
			normal.y = v.y / magnitude;
			normal.z = v.z / magnitude;
			return normal;
		}

		public float this[int index] {
			get {
				if ( index == 0 ) {
					return x;
				} else if ( index == 1 ) {
					return y;
				} else if ( index == 2 ) {
					return z;
				} else {
					//TODO: Throw Exception
					return -1;
				}
			}
			set {
				if ( index == 0 ) {
					x = value;
				} else if ( index == 1 ) {
					y = value;
				} else if ( index == 2 ) {
					z = value;
				} else {
					//TODO: Throw Exception
				}
			}
		}

		public Vector3 normalized {
			get {
				return Vector3.Normalize(this);
			}
		}

		public float magnitude {
			get {
				return (float)Math.Sqrt(this.sqrMagnitude);
			}
		}

		public float sqrMagnitude {
			get {
				return (float)Math.Sqrt( x*x + y*y + z*z );
			}
		}

		public void Scale(Vector3 scalar) {
			x *= scalar.x;
			y *= scalar.y;
			z *= scalar.z;
		}

		public void Scale(float scalar) {
			x *= scalar;
			y *= scalar;
			z *= scalar;
		}

		public void Set( float x, float y, float z )
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public void Normalize()
		{
			float mag = this.magnitude;
			x = x / mag;
			y = y / mag;
			z = z / mag;
		}

		public override string ToString()
		{
			return string.Format("({0},{1},{2})",x,y,z);
		}

		public static bool operator ==( Vector3 v1, Vector3 v2 )
		{
		
			if ( v1.x == v2.x && v1.y == v2.y && v1.z == v2.z ) {
				return true;
			}

			return false;

		}

		public static bool operator !=( Vector3 v1, Vector3 v2 )
		{
		
			if ( v1.x != v2.x && v1.y != v2.y && v1.z != v2.z ) {
				return true;
			}

			return false;

		}

		public static Vector3 operator +(Vector3 v1, Vector3 v2) {
			return new Vector3(v1.x+v2.x,v1.y+v2.y,v1.z+v2.z);
		}

		public static Vector3 operator -(Vector3 v1, Vector3 v2) {
			return new Vector3(v1.x-v2.x,v1.y-v2.y,v1.z-v2.z);
		}

		//This might get confused for dot product... Commenting out.
		//public static Vector3 operator *(Vector3 v1, Vector3 v2) {
		//	return new Vector3(v1.x*v2.x,v1.y*v2.y,v1.z*v2.z);
		//}

		public static Vector3 operator *(Vector3 v1, float scalar) {
			return new Vector3(v1.x*scalar,v1.y*scalar,v1.z*scalar);
		}

		public static Vector3 operator /(Vector3 v1, float scalar) {
			return new Vector3(v1.x/scalar,v1.y/scalar,v1.z/scalar);
		}

	}
}


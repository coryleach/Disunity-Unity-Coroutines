using System;
using System.Collections.Generic;

namespace Disunity
{
	public class GameObject : Object
	{

		//Object Name
		public string name { get; set; }

		//Default Components
		private Transform _transform;
		public Transform transform {
			get {

				if ( _transform == null ) {
					//Get the component
					return null;
				} else {
					return _transform;
				}

			}
			set {
				_transform = value;
			}
		}

		private Rigidbody _rigidbody;
		public Rigidbody rigidbody {
			get {

				if ( _rigidbody == null ) {
					//Get the component
					return null;
				} else {
					return _rigidbody;
				}

			}
			set {
				_rigidbody = value;
			}
		}

		private Collider _collider;
		public Collider collider {
			get {

				if ( _collider == null ) {
					//Get the component
					return GetComponent<Collider>( );
				} else {
					return _collider;
				}

			}
			set {
				_collider = value;
			}
		}

		//Components
		private List<Component> components;

		//Construct with generic/random name
		public GameObject() : this("Object") {
			
		}

		public GameObject(string aName)
		{

			components = new List<Component>();
			this.name = aName;

			//Add a transform by default
			AddComponent<Transform>();
		
		}

		public override string ToString()
		{
			return string.Format("[GameObject: name={0}]", name);
		}

		public void AddComponent( string componentName )
		{
		
			Type componentType = Type.GetType( componentName );

			if ( componentType == null ) {
				//TODO: Print Error/Exception
				return;
			}

			if ( !componentType.IsSubclassOf(typeof(Component)) ) {
				//TODO: Print Error/Exception
				//class must be subclass of component
				return;
			}

			//Instantiate Component
			Component newComponent = (Component)Activator.CreateInstance(componentType);
			newComponent.gameObject = this;
			components.Add(newComponent);

		}

		public void AddComponent<T>()
		{
		
			Type type = typeof(T);

			if ( !type.IsSubclassOf( typeof(Component) ) ) {
				//TODO: Print Error/Throw Exception
				//Must be component type
				return;
			}

			//Instantiate Component
			Component newComponent = (Component)Activator.CreateInstance(type);
			newComponent.gameObject = this;
			components.Add(newComponent);

		}

		public Component GetComponent( string typeName )
		{
		
			Type type = Type.GetType( typeName );

			foreach ( Component component in components ) {
			
				if ( component.GetType() == type || component.GetType().IsSubclassOf(type) ) {
					return component;
				}

			}

			return null;

		}

		public T GetComponent<T>() where T : class {
		
			Type type = typeof(T);

			foreach ( Component component in components ) {
			
				if ( component.GetType() == type || component.GetType().IsSubclassOf(type) ) {
					return (T)(Object)component;
				}

			}

			return null;

		}



	}
}


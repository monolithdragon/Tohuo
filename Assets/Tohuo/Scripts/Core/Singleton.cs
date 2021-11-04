using UnityEngine;

// <summary>
///  That lets you ensure that a class has only one instance, while providing a global access point to this instance. 
/// </summary>
/// <typeparam name="T">That class which instantiable</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this as T;
		}
		else
		{
			Destroy(gameObject);
		}

		Initialize();
	}

	/// <summary>
	/// Override initialize in derived class <see cref="Awake"/>
	/// </summary>
	protected virtual void Initialize() { }
}

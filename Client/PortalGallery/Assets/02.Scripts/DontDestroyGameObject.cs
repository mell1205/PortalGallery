using UnityEngine;
using System.Collections;

public class DontDestroyGameObject : MonoBehaviour
{
	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class LayerDB
{
	public string name;
	public int idx;
	public bool isUsed = false;
}

public class LayerManager : MonoBehaviour {

	public List<LayerDB> layerDB = new List<LayerDB> ();

	void Awake()
	{
		for (int i = 8; i < 32; i++) 
		{
			LayerDB _layer = new LayerDB ();
			_layer.name = "MY_LAYER_" + (i - 8);
			_layer.idx = i;
			_layer.isUsed = false;

			layerDB.Add (_layer);
		}
	}

	public int GetLayerIndex()
	{
		foreach (LayerDB _layer in layerDB) 
		{
			if (_layer.isUsed == false) 
			{
				_layer.isUsed = true;
				return _layer.idx;
			}
		}
		return 0;  
	}
}

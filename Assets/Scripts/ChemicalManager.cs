using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChemicalManager : MonoBehaviour
{
	public static ChemicalManager instance;
	
	public List<string> chemicals = new List<string>();
	[SerializeField] private TMP_Text chemDisplay;
	public string b;
	
	private void Awake()
	{
		if(!instance)
		{
			instance = this;
		}
	}
	
	private void OnGui()
	{
		for(int i = 0; i <= chemicals.Count - 1; i++)
		{
			b = (chemicals[i].ToString());
			chemDisplay.text += b + ' ';
			Debug.Log(chemDisplay);
		}
	}
	
	public void AddChemical(string chemical)
	{
		chemicals.Add(chemical);
	}
}

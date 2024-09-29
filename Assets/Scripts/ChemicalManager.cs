using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class ChemicalManager : MonoBehaviour
{
	public static ChemicalManager instance;

	public List<string> chemicals = new List<string>();
	[SerializeField] private TMP_Text chemDisplay;
	[SerializeField] private TMP_Text nameDisplay;
	private StringBuilder b = new StringBuilder();
	private string acidName;
	private string acidForm;

	private void Awake()
	{
		if (!instance)
		{
		    instance = this;
		}
	}

	private void Update()
	{
		// Update the display text with the concatenated string
		nameDisplay.text = acidName;
		chemDisplay.text = b.ToString(); // Update display text with concatenated string
	}

	public void AddChemical(string chemical)
	{
		b.Append(chemical); // Append the new chemical
		Debug.Log(b.ToString()); // Log the current concatenated string
		chemicals.Add(chemical); // Optionally keep the list if needed
	}

	public void RandomChemical(string name, string form)
	{
	    acidForm = form;
	    acidName = name;
	    Debug.Log("Random Chemical: " + acidName); // Log to verify it’s working
	}
}


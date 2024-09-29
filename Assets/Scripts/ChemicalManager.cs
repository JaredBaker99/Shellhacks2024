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
    private StringBuilder b = new StringBuilder();

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
        chemDisplay.text = b.ToString(); // Update display text with concatenated string
    }

    public void AddChemical(string chemical)
    {
        b.Append(chemical); // Append the new chemical
        Debug.Log(b.ToString()); // Log the current concatenated string
        chemicals.Add(chemical); // Optionally keep the list if needed
    }
}


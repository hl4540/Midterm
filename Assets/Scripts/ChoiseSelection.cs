using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiseSelection : MonoBehaviour
{

    public GameObject[] choisesList;
    public int selectedChoise = 0;

    public void NextChoise()
    {
        choisesList[selectedChoise].SetActive(false);
        selectedChoise = (selectedChoise + 1) % choisesList.Length;
        choisesList[selectedChoise].SetActive(true);
    }


    public void PreviousChoise()
    {
        choisesList[selectedChoise].SetActive(false);
        selectedChoise--;
        if(selectedChoise < 0)
        {
            selectedChoise += choisesList.Length;
        }
        choisesList[selectedChoise].SetActive(true);
    }

    public void SetChoise()
    {
        PlayerPrefs.SetInt("selectedChoise", selectedChoise);
        Debug.Log(PlayerPrefs.GetInt("selectedChoise"));
    }
   
}

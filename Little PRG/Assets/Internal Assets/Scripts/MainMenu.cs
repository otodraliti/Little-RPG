using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public GameObject _MainMenu;
    public GameObject _ClassMenu;
    public SaveHandler SaveHandler;

    public void ToClassMenu()
    {
        _MainMenu.SetActive(false);
        _ClassMenu.SetActive(true);
        SaveHandler._chosenClass.SetActive(false);
    }
    public void ToMainMenu()
    {
        _MainMenu.SetActive(true);
        _ClassMenu.SetActive(false);
        SaveHandler._chosenClass.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }

    public void PlayMenu()
    {
        if (SaveHandler._ClassID != 0)
        {
            SceneManager.LoadScene("FirstLevel");
        }
    }
    public void KnightChosen()
    {
        SaveHandler._ClassID = 1;
        PlayerPrefs.SetInt("_ClassID", SaveHandler._ClassID);
        Debug.Log("Knight Chosen");
        SaveHandler._chosenClass.GetComponent<SpriteRenderer>().sprite = SaveHandler._KnightSprite;
    }
    public void CheifChosen()
    {
        SaveHandler._ClassID = 2;
        PlayerPrefs.SetInt("_ClassID", SaveHandler._ClassID);
        Debug.Log("Cheif Chosen");
        SaveHandler._chosenClass.GetComponent<SpriteRenderer>().sprite = SaveHandler._CheifSprite;
    }
    public void HammerChosen()
    {
        SaveHandler._ClassID = 3;
        PlayerPrefs.SetInt("_ClassID", SaveHandler._ClassID);
        Debug.Log("Hammer Chosen");
        SaveHandler._chosenClass.GetComponent<SpriteRenderer>().sprite = SaveHandler._HammerSprite;
    }

}

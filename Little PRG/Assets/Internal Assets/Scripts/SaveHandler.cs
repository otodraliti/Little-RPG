using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHandler : MonoBehaviour
{
    public GameObject _chosenClass;
    public Sprite _KnightSprite;
    public Sprite _CheifSprite;
    public Sprite _HammerSprite;
    



    public int _ClassID;
    private bool loadComplete;

    private void Update()
    {
        if (loadComplete == false)
        {
            _ClassID = PlayerPrefs.GetInt("_ClassID", _ClassID);
            if (_ClassID == 1)
            {
                _chosenClass.GetComponent<SpriteRenderer>().sprite = _KnightSprite;
            }
            if (_ClassID == 2)
            {
                _chosenClass.GetComponent<SpriteRenderer>().sprite = _CheifSprite;
            }
            if (_ClassID == 3)
            {
                _chosenClass.GetComponent<SpriteRenderer>().sprite = _HammerSprite;
            }
            loadComplete = true;
        }
    }
}

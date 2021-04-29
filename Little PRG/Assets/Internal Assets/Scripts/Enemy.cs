using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Sprite Ghost;
    public Sprite Dummy;

    public GameObject CurrentEnemy;


    public int EnemyID;
    public string EnemyName;
    public int MaxHP;
    public int CurHP;
    public int AttackPower;
    public int DeffensePowwer;
    public int curDeffence;
    public int ActionsAvable;

    public List<string> AttackPhrase;
    public List<string> DefPhrease;

    public bool isWin;
    public int WinCondition;

    public bool isDead;

    private void Start()
    {
        RandomEnemy();
    }

    private void RandomEnemy()
    {
        EnemyID = Random.Range(1, 3);
        if (EnemyID == 1)
        {
            EnemyName = "Gost";
            MaxHP = 20;
            CurHP = MaxHP;
            AttackPower = 1;
            DeffensePowwer = 1;
            ActionsAvable = 2;
            curDeffence = 0;
            CurrentEnemy.gameObject.GetComponent<SpriteRenderer>().sprite = Ghost;
            AttackPhrase = new List<string> { "WoOOOOooO!!!!", "Face your worst NIGHTMARE!!!", "Im Casper 2.0", "Im literally NEVER lose", "Face the FEAR ITSELF" };
            DefPhrease = new List<string> { "I will just wait untill you close the game...", "Actualy, i dont want to fight...", "Dont tuch me with THESE hands!!", "Im gonna just ignore you", "Fighting. pfff, im above that" };
        }

        if (EnemyID == 2)
        {
            EnemyName = "Dummy";
            MaxHP = 40;
            CurHP = MaxHP;
            AttackPower = 2;
            DeffensePowwer = 2;
            ActionsAvable = 2;
            curDeffence = 0;
            CurrentEnemy.gameObject.GetComponent<SpriteRenderer>().sprite = Dummy;
            AttackPhrase = new List<string> { "Dummy not dumb!", "I will crush you!... or not", "Face the Mighty Dummy!", "Mom said that im strong!", "I use to dream of becoming like you!" };
            DefPhrease = new List<string> { "I'm not fat, my bones just wide!", "Im one eyed, hope you know why...", "Fork used to be my favorite weapon...", "You looks overbrutal", "Otodraliti made me C:" };
        }
        isDead = false;
    }
    private void Update()
    {
        NewEnemy();
    }
    public void NewEnemy()
    {
        if (isDead == true)
        {
            WinCondition += 1;
            Win();
            RandomEnemy();
        }
    }

    public void Win()
    {
        if (WinCondition == 2)
        {
            isWin = true;
        }
    }

}

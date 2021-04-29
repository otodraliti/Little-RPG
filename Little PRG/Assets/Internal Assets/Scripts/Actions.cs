using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{

    public Classes Classes;
    public Enemy Enemy;
    public Text Reactions;


    
    public Sprite Sword;
    public Sprite Shield;
    public Sprite Heal;

    private bool PlayerDidAtack;

    public GameManager gameManager;



    private void Start()
    {
        Classes.SaveHandler._chosenClass.transform.position = PlayerStartPose.transform.position;
        moveTimer = maxMoveTimer;
        backTimer = maxBackTimer;

    }

    private float EactionDelay;
    public float maxEactionDelay;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            EnemyAtack();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerAtack();
        }

        PlayerActionAnimation();
        EnemyAction();
        EnemyActionAnimation();


    }

    private void EnemyAction()
    {
        if (isEnemyActed == false)
        {
            if (maxEactionDelay > 0)
            {
                EactionDelay -= Time.deltaTime;
                if (EactionDelay < 0)
                {
                    int RandomAtack = Random.Range(0, 2);
                    Debug.Log(RandomAtack);
                    if (RandomAtack == 0)
                    {
                        EnemyAtack();
                    }
                    if (RandomAtack == 1)
                    {
                        EnemyDef();
                    }
                }
            }

        }

    }
    private void PlayerActionAnimation()
    {
        if (PlayerDidAtack == true)
        {

            if (maxMoveTimer > 0)
            {
                moveTimer -= Time.deltaTime;
                Vector2 enemyPosition = Enemy.CurrentEnemy.transform.position;
                Vector2 PlayerPosition = Classes.SaveHandler._chosenClass.transform.position;
                Classes.SaveHandler._chosenClass.transform.position = Vector2.Lerp(PlayerPosition, enemyPosition, AtackSpeed * Time.deltaTime);
                
                if (moveTimer < 0)
                {

                    if (maxBackTimer > 0)
                    {
                        backTimer -= Time.deltaTime;
                        Vector2 TargetPose = PlayerStartPose.transform.position;
                        Classes.SaveHandler._chosenClass.transform.position = Vector2.Lerp(PlayerPosition, TargetPose, AtackSpeed * Time.deltaTime);
                        if (backTimer < 0)
                        {
                            moveTimer = maxMoveTimer;
                            backTimer = maxBackTimer;
                            PlayerDidAtack = false;
                            isEnemyActed = false;
                        }
                    }
                }
            }
        }
    }

    private bool EnemyDidAtack;
    private void EnemyActionAnimation()
    {
        isEnemyActed = true;
        if (EnemyDidAtack == true)
        {
            if (maxMoveTimer > 0)
            {
                moveTimer -= Time.deltaTime;
                Vector2 enemyPosition = Enemy.CurrentEnemy.transform.position;
                Vector2 PlayerPosition = Classes.SaveHandler._chosenClass.transform.position;
                Enemy.CurrentEnemy.transform.position = Vector2.Lerp(enemyPosition, PlayerPosition, AtackSpeed * Time.deltaTime);

                if (moveTimer < 0)
                {

                    if (maxBackTimer > 0)
                    {
                        backTimer -= Time.deltaTime;
                        Vector2 TargetPose = EnemyStartPose.transform.position;
                        Enemy.CurrentEnemy.transform.position = Vector2.Lerp(enemyPosition, TargetPose, AtackSpeed * Time.deltaTime);
                        if (backTimer < 0)
                        {
                            moveTimer = maxMoveTimer;
                            backTimer = maxBackTimer;
                            EnemyDidAtack = false;
                            

                        }
                    }
                }
            }
        }

    }



    public void PlayerHealing()
    {
        if (Classes.CurHP + Classes.HealPower <= Classes.MaxHP)
        {
            Classes.CurHP += Classes.HealPower;
        }
        else
        {
            Classes.CurHP = Classes.MaxHP;
        }
        HealVFX.GetComponent<ParticleSystem>().Play(true);
        isEnemyActed = false;
    }

    public float AtackSpeed;
    public float maxMoveTimer;
    private float moveTimer;
    public float maxBackTimer;
    private float backTimer;
    public GameObject PlayerStartPose;
    public GameObject AtackVFX;
    public GameObject DefVFX;
    public GameObject HealVFX;


    public GameObject EnemyStartPose;
    public GameObject EnemyAtackVFX;
    public GameObject EnemyDefVFX;



    public void PlayerAtack()
    {
        int remainder = Enemy.curDeffence - Classes.AttackPower;
        if (remainder < 0)
        {
            Enemy.curDeffence = 0;
            Enemy.CurHP -= -remainder;
        }
        else
        {
            Enemy.curDeffence -= Classes.AttackPower;
        }
        PlayerDidAtack = true;
        AtackVFX.GetComponent<ParticleSystem>().Play(true);
        
    }



    public void PlayerDef()
    {
        Classes.curDeffence += Classes.DeffensePower;
        DefVFX.GetComponent<ParticleSystem>().Play(true);
        isEnemyActed = false;
    }


    public void EnemyAtack()
    {
        int RandomPrhase = Random.Range(0, Enemy.AttackPhrase.Count);
        Reactions.text = Enemy.AttackPhrase[RandomPrhase];

        int remainder = Classes.curDeffence - Enemy.AttackPower;
        if (remainder < 0)
        {
            Classes.curDeffence = 0;
            Classes.CurHP -= -remainder;
        }
        else
        {
            Classes.curDeffence -= Enemy.AttackPower;
        }
        EnemyDidAtack = true;
        EnemyAtackVFX.GetComponent<ParticleSystem>().Play(true);
    }


    private bool isEnemyActed = true;

    public void EnemyDef()
    {
        int RandomPrhase = Random.Range(0, Enemy.DefPhrease.Count);
        Reactions.text = Enemy.DefPhrease[RandomPrhase];
        Enemy.curDeffence += Enemy.DeffensePowwer;
        isEnemyActed = true;
        EnemyDefVFX.GetComponent<ParticleSystem>().Play(true);
    }

}

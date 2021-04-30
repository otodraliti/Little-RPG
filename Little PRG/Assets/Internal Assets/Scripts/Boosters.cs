using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosters : MonoBehaviour
{
    Classes player;
    Enemy enemy;
    GameManager gameManager;

    public GameObject SwordShiledPrefab;
    public GameObject SwordHealPrefab;
    public GameObject ShieldHealPrefab;

    int RandomBoost1;
    int RandomBoost2;
    int RandomBoost3;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Classes>();
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Enemy>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        RandomBoost1 = Random.Range(0, this.gameObject.transform.childCount);
        RandomBoost2 = Random.Range(0, this.gameObject.transform.childCount);
        RandomBoost3 = Random.Range(0, this.gameObject.transform.childCount);
    }
    public bool RandomComplete;
    private void Update()
    {
        if (RandomComplete == false)
        {
            if (RandomBoost2 == RandomBoost1)
            {
                RandomBoost2 = Random.Range(0, this.gameObject.transform.childCount);
            }
            else
            {
                if (RandomBoost3 == RandomBoost2 || RandomBoost3 == RandomBoost1)
                {
                    RandomBoost3 = Random.Range(0, this.gameObject.transform.childCount);
                }
                else
                {
                    this.gameObject.transform.GetChild(RandomBoost1).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(RandomBoost2).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(RandomBoost3).gameObject.SetActive(true);
                    RandomComplete = true;
                }
            }
        }


        
    }

    public void Sword()
    {
        player.AttackPower += 5;
        enemy.WinCondition = 0;
        this.gameObject.SetActive(false);
    }

    public void Shield()
    {
        player.DeffensePower += 5;
        enemy.WinCondition = 0;
        this.gameObject.SetActive(false);
    }

    public void Heal()
    {
        player.HealPower += 5;
        enemy.WinCondition = 0;
        this.gameObject.SetActive(false);
    }

    public void SwordShield()
    {
        gameManager.ActionPrefabs.Add(SwordShiledPrefab);
        enemy.WinCondition = 0;
        this.gameObject.SetActive(false);
    }

    public void SwordHeal()
    {
        gameManager.ActionPrefabs.Add(SwordHealPrefab);
        enemy.WinCondition = 0;
        this.gameObject.SetActive(false);
    }

    public void ShieldHeal()
    {
        gameManager.ActionPrefabs.Add(ShieldHealPrefab);
        enemy.WinCondition = 0;
        this.gameObject.SetActive(false);
    }
}

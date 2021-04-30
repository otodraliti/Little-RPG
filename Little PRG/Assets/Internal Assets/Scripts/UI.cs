using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Classes Classes;
    public Slider PlayerSlider;
    public Slider PlayerShiledSlider;
    public GameObject GameUI;
    public GameObject DeathUI;
    public GameObject WinUI;

    public Text playerHpText;
    public Text playerArmorText;



    public Enemy Enemy;
    public Slider EnemySlider;
    public Slider EnemyShieldSlider;
    public GameObject EnemyWin;

    public Text EnemyHpText;
    public Text EnemyArmorText;


    private bool isLoadComplete;

    void Update()
    {
        Loading();
        Sliders();
        Texts();
        if (isLoadComplete == true && Classes.isloadComplete == true)
        {
            PlayerDeath();
        }

    }
    private void Texts()
    {
        playerHpText.text = Classes.CurHP.ToString("0");
        playerArmorText.text = Classes.curDeffence.ToString("0");

        EnemyHpText.text = Enemy.CurHP.ToString("0");
        EnemyArmorText.text = Enemy.curDeffence.ToString("0");

    }

    private void PlayerDeath()
    {
        if (Classes.isDead == true)
        {
            Debug.Log(Classes.CurHP);
            GameUI.gameObject.SetActive(false);
            DeathUI.gameObject.SetActive(true);
        }
        if (Enemy.isWin == true)
        {
            //GameUI.gameObject.SetActive(false);
            //WinUI.gameObject.SetActive(true);
        }
    }

    private void Loading()
    {
        if (Classes.isloadComplete == true)
        {
            if (isLoadComplete == false)
            {
                PlayerSlider.maxValue = Classes.MaxHP;
                PlayerShiledSlider.maxValue = Classes.MaxHP;


                isLoadComplete = true;
            }
        }
    }
    private void Sliders()
    {
        EnemySlider.maxValue = Enemy.MaxHP;
        EnemyShieldSlider.maxValue = Enemy.MaxHP;


        PlayerSlider.value = Classes.CurHP;
        EnemySlider.value = Enemy.CurHP;
        PlayerShiledSlider.value = Classes.curDeffence;
        EnemyShieldSlider.value = Enemy.curDeffence;
        if (Enemy.curDeffence == 0)
        {
            EnemyShieldSlider.gameObject.SetActive(false);
        }
        else
        {
            EnemyShieldSlider.gameObject.SetActive(true);
        }

        if (Classes.curDeffence == 0)
        {
            PlayerShiledSlider.gameObject.SetActive(false);
        }
        else
        {
            PlayerShiledSlider.gameObject.SetActive(true);
        }


        if (Classes.isloadComplete == true)
        {
            if (Classes.CurHP <= 0)
            {
                PlayerSlider.gameObject.SetActive(false);
                Classes.isDead = true;
            }
            else
            {
                PlayerSlider.gameObject.SetActive(true);
            }


            if (Enemy.CurHP <= 0)
            {
                EnemySlider.gameObject.SetActive(false);
                Enemy.isDead = true;
            }
            else
            {
                EnemySlider.gameObject.SetActive(true);
            }
        }
    }



    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToNextLevel()
    {
        SceneManager.LoadScene("SceondLevel");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

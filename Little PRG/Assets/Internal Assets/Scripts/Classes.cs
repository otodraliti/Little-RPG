using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes: MonoBehaviour
{
    public SaveHandler SaveHandler;


    public int ClassID;
    public string ClassName;
    public int MaxHP;
    public int CurHP;
    public int AttackPower;
    public int DeffensePower;
    public int curDeffence;
    public int HealPower;

    public bool isDead;

    public bool isloadComplete;

    void Update()
    {
        Loading();


    }

    private void Loading()
    {
        if (isloadComplete == false)
        {
            ClassID = SaveHandler._ClassID;

            if (ClassID == 1)
            {
                ClassName = "Knight";
                MaxHP = 110;
                CurHP = MaxHP;
                AttackPower = 2;
                DeffensePower = 2;
                HealPower = 1;
                isloadComplete = true;
            }
            if (ClassID == 2)
            {
                ClassName = "Cheif";
                MaxHP = 110;
                CurHP = MaxHP;
                AttackPower = 1;
                DeffensePower = 2;
                HealPower = 3;
                isloadComplete = true;
            }
            if (ClassID == 3)
            {
                ClassName = "Hammer";
                MaxHP = 100;
                CurHP = MaxHP;
                AttackPower = 3;
                DeffensePower = 1;
                HealPower = 2;
                isloadComplete = true;
            }
        }
    }


}

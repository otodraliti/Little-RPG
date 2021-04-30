using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graids : MonoBehaviour
{
    Classes player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Classes>();
    }

    private void Update()
    {
        if (this.gameObject.tag == "Sword")
        {
            this.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = player.AttackPower.ToString("0");
        }
        if (this.gameObject.tag == "Shield")
        {
            this.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = player.DeffensePower.ToString("0");
        }
        if (this.gameObject.tag == "Heal")
        {
            this.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = player.HealPower.ToString("0");
        }
    }
}

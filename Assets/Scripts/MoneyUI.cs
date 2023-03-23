using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    
    private void Update()
    {
        moneyText.text = "$" + PlayerStats.Money;
    }
}

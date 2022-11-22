using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] TMP_InputField _balanceField;

    int _balance = 0;

    private void Awake()
    {
        DrawBalance();
    }

    public int ReturnBalance()
    {
        return _balance;
    }

    void DrawBalance()
    {
        _balanceField.text = "Balance " + _balance.ToString();
    }

    public void InsertCoin()
    {
        _balance += 5;

        DrawBalance();
    }

    public void DoBet(byte bet)
    {
        _balance -= bet;

        DrawBalance();
    }

    public void AddBalance(int prize)
    {
        _balance += prize;

        DrawBalance();
    }
}

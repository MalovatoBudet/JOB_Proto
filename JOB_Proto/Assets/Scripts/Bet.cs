using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bet : MonoBehaviour
{
    [SerializeField] TableSetter _tableSetter;
    [SerializeField] TMP_InputField _betField;
    [SerializeField] Balance _balance;

    byte _bet = 1;

    void Awake()
    {
        _tableSetter.SetTable(_bet);
        _tableSetter.SetPoints(_bet);
        DrawBet();
    }

    public void BetOne()
    {
        _bet++;

        if (_bet > 5 || _bet > _balance.ReturnBalance())
        {
            _bet = 1;
        }

        DrawBet();
        _tableSetter.SetPoints(_bet);
    }

    public void CheckBetMax()
    {
        if (_bet > _balance.ReturnBalance())
        {
            _bet = (byte)_balance.ReturnBalance();

            if (_bet <= 0)
            {
                _bet = 1;
            }
        }

        DrawBet();
        _tableSetter.SetPoints(_bet);
    }

    public void BetMax()
    {
        _bet = 5;
        CheckBetMax();
    }

    public void SetBet(byte bet)
    {
        _bet = bet;
        DrawBet();
        _tableSetter.SetPoints(_bet);
    }

    void DrawBet()
    {
        _betField.text = "Bet " + _bet.ToString();
    }

    public byte ReturnBet()
    {
        return _bet;
    }
}

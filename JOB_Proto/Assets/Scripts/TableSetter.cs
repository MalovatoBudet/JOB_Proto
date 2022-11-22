using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableSetter : MonoBehaviour
{
    [SerializeField] PayoutTable _payoutTable;
    [SerializeField] TMP_InputField[] _pointsTable;
    [SerializeField] TMP_InputField[] _pokerHandsTable;

    public void SetTable(byte stake)
    {
        for (int i = 0; i < _payoutTable.payout.Count; i++)
        {
            _pokerHandsTable[i].text = _payoutTable.payout[i].pokerHand;

            _pointsTable[i].text = _payoutTable.payout[i].bets[stake].ToString();
        }
    }

    public void SetPoints(byte stake)
    {
        for (int i = 0; i < _payoutTable.payout.Count; i++)
        {
            _pointsTable[i].text = _payoutTable.payout[i].bets[stake].ToString();
        }
    }
}

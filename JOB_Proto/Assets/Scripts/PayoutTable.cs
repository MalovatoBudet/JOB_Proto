using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PayoutTable), menuName = "Scriptable Objects/" + nameof(PayoutTable))]
public class PayoutTable : ScriptableObject
{
    public List<Payout> payout;
}

[Serializable]
public struct Payout
{
    public string pokerHand;
    public int[] bets;
}

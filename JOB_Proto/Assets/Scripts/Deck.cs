using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Deck), menuName = "Scriptable Objects/" + nameof(Deck))]
public class Deck : ScriptableObject
{
    public List<Card> deck;
}

[Serializable]
public struct Card
{
    public Sprite sprite;
    public byte suit; // 1-Diamonds,  2-Hearts, 3-Spades, 4-Clubs
    public byte rank; // 1-Ace, 2-2, ..., 10-10, 11-Jack, 12-Queen, 13-King
}
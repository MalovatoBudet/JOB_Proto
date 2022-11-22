using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] CardInfo[] _hand;
    [SerializeField] Draw _draw;

    void Awake()
    {
        DisableColliders();
        UnHold();
    }

    public void Draw()
    {
        _draw.InstantiateDeck();

        UnHold();
        Shuffle();
        EnableColliders();
    }

    public void Deal()
    {
        Shuffle();
        Sort();
        DisableColliders();
    }
    
    void UnHold()
    {
        for (int i = 0; i < _hand.Length; i++)
        {
            _hand[i].UnHold();
        }
    }
    void DisableColliders()
    {
        for (int i = 0; i < _hand.Length; i++)
        {
            _hand[i].DisableCollider();
        }
    }

    void EnableColliders()
    {
        for (int i = 0; i < _hand.Length; i++)
        {
            _hand[i].EnableCollider();
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < _hand.Length; i++)
        {
            if (!_hand[i].IsHold)
            {
                _draw.DrawRandomCard(_hand[i]);
            }
        }
    }

    public byte Sort()
    {
        byte[] suit = new byte[5];
        byte[] rank = new byte[5];
        byte[,] card = new byte[5, 2];

        for (int i = 0; i < _hand.Length; i++)
        {
            suit[i] = _hand[i].Suit;
            rank[i] = _hand[i].Rank;

            card[i, 0] = rank[i];
            card[i, 1] = suit[i];
        }

        byte temp = 0;

        for (int write = 0; write < _hand.Length; write++)
        {
            for (int sort = 0; sort < _hand.Length - 1; sort++)
            {
                if (card[sort, 0] > card[sort + 1, 0])
                {
                    temp = card[sort + 1, 0];
                    card[sort + 1, 0] = card[sort, 0];
                    card[sort, 0] = temp;

                    temp = card[sort + 1, 1];
                    card[sort + 1, 1] = card[sort, 1];
                    card[sort, 1] = temp;
                }
            }
        }

        return CombinationChecker.CheckCombinations(card);
    }
}

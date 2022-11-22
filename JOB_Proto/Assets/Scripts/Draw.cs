using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Draw : MonoBehaviour
{
    [SerializeField] Deck _deckSO;

    Deck _deck;

    public void InstantiateDeck()
    {
        _deck = Instantiate(_deckSO);
    }

    public void DrawRandomCard(CardInfo cardInfo)
    {
        int randomCard = Random.Range(0, _deck.deck.Count);

        cardInfo.Rank = _deck.deck[randomCard].rank;
        cardInfo.Suit = _deck.deck[randomCard].suit;

        Sprite sprite = _deck.deck[randomCard].sprite;
        SpriteRenderer spriteRenderer = cardInfo.SpriteRenderer;
        spriteRenderer.sprite = sprite;

        _deck.deck.RemoveAt(randomCard);
    }
}

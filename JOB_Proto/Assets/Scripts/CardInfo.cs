using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CardInfo : MonoBehaviour
{
    [SerializeField] Collider2D _collider2D;
    public Collider2D Collider2D
    {
        get { return _collider2D; }
        set { _collider2D = value; }
    }

    [SerializeField] SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer
    {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }

    [SerializeField] byte _suit;
    public byte Suit
    {
        get { return _suit; }
        set { _suit = value; }
    }

    [SerializeField] byte _rank;
    public byte Rank
    {
        get { return _rank; }
        set { _rank = value; }
    }

    [SerializeField] bool _isHold;
    public bool IsHold
    {
        get { return _isHold; }
        set { _isHold = value; }
    }

    [SerializeField] TMP_Text _text;
    public TMP_Text Text
    {
        get { return _text; }
        set { _text = value; }
    }

    void Awake()
    {
        Text.enabled = false;
    }

    void OnMouseDown()
    {
        if (!IsHold)
        {
            Hold();
        }
        else
        {
            UnHold();
        }
    }   

    public void Hold()
    {
        IsHold = true;
        Text.enabled = true;
    }

    public void UnHold()
    {
        IsHold = false;
        Text.enabled = false;
    }

    public void DisableCollider()
    {
        Collider2D.enabled = false;
    }

    public void EnableCollider()
    {
        Collider2D.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button _insertCoinButton;
    [SerializeField] Button _betOneButton;
    [SerializeField] Button _betMaxButton;
    [SerializeField] Button _drawOrDealButton;

    [SerializeField] Balance _balance;

    private void Awake()
    {
       // SetButtonStatus();
    }


    public void SetButtonStatus()
    {
        if (_balance.ReturnBalance() <= 0)
        {
            _insertCoinButton.interactable = true;

            _betOneButton.interactable = false;
            _betMaxButton.interactable = false;
            _drawOrDealButton.interactable = false;
        }
        else
        {
            _insertCoinButton.interactable = false;

            _betOneButton.interactable = true;
            _betMaxButton.interactable = true;
            _drawOrDealButton.interactable = true;
        }
    }

    public void BlockBetButtons()
    {
        _betOneButton.interactable = false;
        _betMaxButton.interactable = false;
    }

    public void UnblockBetButtons()
    {
        _betOneButton.interactable = true;
        _betMaxButton.interactable = true;
    }

    public void BlockDrawOrDealButton()
    {
        _drawOrDealButton.interactable = false;
    }

    public void UnblockDrawOrDealButton()
    {
        _drawOrDealButton.interactable = true;
    }

    public void BlockInsertCoinButton()
    {
        _insertCoinButton.interactable = false;
    }

    public void UnblockInsertCoinButton()
    {
        _insertCoinButton.interactable = true;
    }
}

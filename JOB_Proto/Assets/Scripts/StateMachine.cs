using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] PayoutTable _payoutTable;
    [SerializeField] Bet _bet;
    [SerializeField] Balance _balance;
    [SerializeField] Hand _hand;
    [SerializeField] ButtonManager _buttonManager;
    [SerializeField] StateEnum _stateEnum;

    [SerializeField] TMP_InputField _resultField;

    void Start()
    {
        _balance.AddBalance(Progress.Instance.Points);
        _stateEnum = Progress.Instance.StateEnum;

        SetState();
        _resultField.text = "";
    }

    public void SetState()
    {
        if (_balance.ReturnBalance() > 0 && _stateEnum == StateEnum.InsertCoin)
        {
            _stateEnum = StateEnum.Draw;

            Progress.Instance.SavePoints(_balance.ReturnBalance());
        }

        ExecuteState();
    }

    public void ExecuteState()
    {
        if (_stateEnum == StateEnum.InsertCoin)
        {
            _buttonManager.BlockBetButtons();
            _buttonManager.BlockDrawOrDealButton();
            _buttonManager.UnblockInsertCoinButton();
        }

        if (_stateEnum == StateEnum.Draw)
        {
            _buttonManager.BlockInsertCoinButton();
            _buttonManager.UnblockBetButtons();
            _buttonManager.UnblockDrawOrDealButton();
        }

        if (_stateEnum == StateEnum.Deal)
        {
            _buttonManager.BlockBetButtons();
            _resultField.text = "";
        }
    }

    public void DrawOrDeal()
    {
        if (_stateEnum == StateEnum.Draw)
        {
            _balance.DoBet(_bet.ReturnBet());
            _hand.Draw();
            Progress.Instance.SavePoints(_balance.ReturnBalance());
            _stateEnum = StateEnum.Deal;
        }
        else if (_stateEnum == StateEnum.Deal)
        {
            _hand.Deal();
            _balance.AddBalance(CombinationChecker.Result(_hand.Sort(), _bet.ReturnBet(), _payoutTable, _resultField));
            Progress.Instance.SavePoints(_balance.ReturnBalance());
            _bet.CheckBetMax();

            if (_balance.ReturnBalance() <= 0)
            {
                _stateEnum = StateEnum.InsertCoin;
                Progress.Instance.SaveEnum(_stateEnum);
            }
            else
            {
                _stateEnum = StateEnum.Draw;
            }
        }
    }
}

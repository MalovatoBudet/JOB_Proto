using TMPro;
using UnityEngine;

public static class CombinationChecker
{
    public static byte CheckCombinations(byte[,] card)
    {
        byte arrayLength = (byte)(card.Length / 2);
        byte[] temp = new byte[3];
        bool jOB = false;

        if (card[0, 0] == card[3, 0]
         || card[1, 0] == card[4, 0])
        {
            return 3;
        }

        if (card[0, 0] == card[1, 0] && card[0, 0] == card[2, 0] && card[3, 0] == card[4, 0]
         || card[2, 0] == card[3, 0] && card[2, 0] == card[4, 0] && card[0, 0] == card[1, 0])
        {
            return 4;
        }

        for (int i = 0; i < arrayLength - 1; i++)
        {
            if (card[i, 1] == card[i + 1, 1])
            {
                temp[0]++;
            }

            if (card[i, 0] + 1 == card[i + 1, 0])
            {
                temp[1]++;
            }

            if (card[i, 0] == card[i + 1, 0])
            {
                temp[2]++;

                if (card[i, 0] >= 11 || card[i, 0] == 1)
                {
                    jOB = true;
                }
            }
        }

        if (temp[0] == temp[1] && temp[0] == arrayLength - 1)
        {
            return 2;
        }

        if (temp[0] == arrayLength - 1)
        {
            if (card[0, 0] == 1 && card[1, 0] == 10 && card[2, 0] == 11 && card[3, 0] == 12 && card[4, 0] == 13)
            {
                return 1;
            }
            else
            {
                return 5;
            }
        }

        if (temp[1] == arrayLength - 1)
        {
            return 6;
        }

        if (card[0, 0] == card[1, 0] && card[0, 0] == card[2, 0]
         || card[1, 0] == card[2, 0] && card[1, 0] == card[3, 0]
         || card[2, 0] == card[3, 0] && card[2, 0] == card[4, 0])
        {
            return 7;
        }

        if (temp[2] == arrayLength - 3)
        {
            return 8;
        }

        if (jOB && temp[2] == arrayLength - 4)
        {
            return 9;
        }

        return 0;
    }

    public static int Result(byte result, int bet, PayoutTable payoutTable, TMP_InputField tMP_InputField)
    {
        int prize = 0;

        switch (result)
        {
            case 1:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize = payoutTable.payout[result - 1].bets[bet];
                break;
            case 2:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize = payoutTable.payout[result - 1].bets[bet];
                break;
            case 3:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize += payoutTable.payout[result - 1].bets[bet];
                break;
            case 4:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize += payoutTable.payout[result - 1].bets[bet];
                break;
            case 5:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize = payoutTable.payout[result - 1].bets[bet];
                break;
            case 6:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize = payoutTable.payout[result - 1].bets[bet];
                break;
            case 7:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize = payoutTable.payout[result - 1].bets[bet];
                break;
            case 8:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize = payoutTable.payout[result - 1].bets[bet];
                break;
            case 9:
                tMP_InputField.text = payoutTable.payout[result - 1].pokerHand;
                prize = payoutTable.payout[result - 1].bets[bet];
                break;
            default:
                tMP_InputField.text = "Bet Lost";
                prize = 0;
                break;
        }

        return prize;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AddLogic : MonoBehaviour
{
    private int[] varIn = new int[7];
    private int[] varOrnam = { 1, 2, 3, 4, 1, 2, 3};
    
    private int attempt = 1, normAtt = 0, factor = 7, points = 0;
    private bool isReady = false, isCorrect = false, isUncorrect  = false, isWin = false, isLoss = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (isReady)
        {
            for (int i = 0; i < varIn.Length; i++)
            {
                if (varIn[i] == varOrnam[i])
                {
                    normAtt += 1;
                }
            }
        }
        if (normAtt == 7)
        {
            isCorrect = true;
        }
        else
        {
            isUncorrect = true;
        }


        if (isCorrect)
        {
            isWin = true;
        }
        else if(isUncorrect)
        {
            isLoss = true;
        }
        if (isWin)
        {
            switch (attempt)
            {
                case 1: factor = 7; break;
                case 2: factor = 6; break;
                case 3: factor = 5; break;
                case 4: factor = 4; break;
                case 5: factor = 3; break;
                case 6: factor = 2; break;
                case 7: factor = 1; break;
            }
            points = factor * 10;
        }
        else if (isLoss)
        {

        }
    }

    public void newAttempt()
    { 
        if (attempt <= 7)
        {
            attempt++;
        }
    }
}

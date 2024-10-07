using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class AddLogic : MonoBehaviour
{
    private int[] varIn = new int[7];
    private int[] varOrnam = { 4, 2, 4, 1, 3, 1, 2 };
    private int thisOrnament = 0;
    private int attempt = 1, normAtt = 0, factor = 7, points = 0;
    private bool isReady = false, isAnswer = false, isCorrect = false, isUncorrect = false, isWin = false, isLoss = false;

    [SerializeField] private TMP_Text _factor, _points;
    [SerializeField] private GameObject _ListenBut, _StartBut, _TryAlsoBut, _ContinueBut;
    [SerializeField] private GameObject _runLine;
    [SerializeField] private float _cooldown = 9;
    [SerializeField] private bool isAtt = true;

    [SerializeField] private GameObject _buben, _palka;
    [SerializeField] private float _cooldown2 = 9;

    void Start()
    {
        _ListenBut.SetActive(false);
        _StartBut.SetActive(false);
        _TryAlsoBut.SetActive(false);
        _ContinueBut.SetActive(false);

        isAtt = true;
        _cooldown = 9;
    }
    void Update()
    {
        if (!isReady)
        {
            _cooldown -= Time.deltaTime;
        }
        if (_cooldown < 0)
        {
            isAtt = false;
            _ListenBut.SetActive(true);
            _StartBut.SetActive(true);
        }
        else
        {
            isAtt = true;
        }

        _factor.text = factor.ToString();
        _points.text = points.ToString();
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
        if (thisOrnament >= 7)
        {
            isAnswer = true;
        }
        if (isReady)
        {
            if (isAnswer)
            {
                if (normAtt >= 7)
                {
                    isCorrect = true;
                }
                else
                {
                    isUncorrect = true;
                }
            }
        }


        if (isCorrect)
        {
            isWin = true;
        }
        else if (isUncorrect)
        {
            isLoss = true;
        }
        if (isWin)
        {
            points = factor * 10;
            _ContinueBut.SetActive(true);
        }
        else if (isLoss)
        {
            points = 0;
            _TryAlsoBut.SetActive(true);
        }
    }

    public void Ready()
    {
        isReady = true;
        _cooldown = 9;
        _ListenBut.SetActive(false);
        _StartBut.SetActive(false);
        StartCoroutine(RespawnBub());
    }

    public void newAttempt()
    {
        if (attempt <= 7 && !isAtt)
        {
            _ListenBut.SetActive(false);
            _StartBut.SetActive(false);
            attempt++;
            GameObject lines = Instantiate(_runLine, _runLine.transform.position, _runLine.transform.rotation);
            lines.transform.SetParent(_runLine.transform);
            _cooldown = 9;
            StartCoroutine(RespawnBub());
        }
    }

    public void SetOrnam1()
    {
        if (isReady)
        {
            if (thisOrnament < 7)
            {
                varIn[thisOrnament] = 1;
            }
            thisOrnament++;
            if (thisOrnament == 7)
            {
                for (int i = 0; i < varIn.Length; i++)
                {
                    if (varIn[i] == varOrnam[i])
                    {
                        normAtt += 1;
                    }
                }
                StartCoroutine(RespawnBub());
            }
        }
    }
    public void SetOrnam2()
    {
        if (isReady)
        {
            if (thisOrnament < 7)
            {
                varIn[thisOrnament] = 2;
            }
            thisOrnament++;
            if (thisOrnament == 7)
            {
                for (int i = 0; i < varIn.Length; i++)
                {
                    if (varIn[i] == varOrnam[i])
                    {
                        normAtt += 1;
                    }
                }
                StartCoroutine(RespawnBub());
            }
        }
    }
    public void SetOrnam3()
    {
        if (isReady)
        {
            if (thisOrnament < 7)
            {
                varIn[thisOrnament] = 3;
            }
            thisOrnament++;
            if (thisOrnament == 7)
            {
                for (int i = 0; i < varIn.Length; i++)
                {
                    if (varIn[i] == varOrnam[i])
                    {
                        normAtt += 1;
                    }
                }
                StartCoroutine(RespawnBub());
            }
        }
    }
    public void SetOrnam4()
    {
        if (isReady)
        {
            if (thisOrnament < 7)
            {
                varIn[thisOrnament] = 4;
            }
            thisOrnament++;
            if (thisOrnament == 7)
            {
                for (int i = 0; i < varIn.Length; i++)
                {
                    if (varIn[i] == varOrnam[i])
                    {
                        normAtt += 1;
                    }
                }
                StartCoroutine(RespawnBub());
            }
        }
    }

    IEnumerator RespawnBub()
    {
        yield return new WaitForSeconds(1);
        _buben.SetActive(false);
        _palka.SetActive(false);
        GameObject bubens = Instantiate(_buben, _buben.transform.position, _buben.transform.rotation);
        GameObject palkas = Instantiate(_palka, _palka.transform.position, _palka.transform.rotation);
        Destroy(bubens, 10);
        Destroy(palkas, 10);
        _buben.SetActive(true);
        _palka.SetActive(true);
    }

    public void GoToLoad()
    {
        Application.OpenURL("https://vk.com/increatives");
    }
}

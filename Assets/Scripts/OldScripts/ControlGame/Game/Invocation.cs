using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    [SerializeField] private GameObject[] _invocType = new GameObject[5];
    private int _count;
    private int j;
    [SerializeField] private GameObject[] _invocation = new GameObject[10];
    [SerializeField] private bool _type = false;
    private int _chance;

    [SerializeField] private int fee;
    static public int factorShaman = 3;
    [SerializeField] private bool type;

    [SerializeField] private GameObject _invoc0, _invoc1;

    void Start()
    {

        if (!_type)
        {
            if (Player._countPeople >= 3)
            {
                _count = Player._countPeople / 3;
            }
            else
            {
                _count = 1;
            }
            for (int i = 0; i < _count; i++)
            {
                _invocType[i].SetActive(false);
            }
            _chance = Random.Range(0, 5);
            _invocType[_chance].SetActive(true);
        }
        else if (_type)
        {
            _count = 0;
            _chance = Random.Range(0, 5);
            _invocType[_chance].SetActive(true);
        }
        j = Random.Range(0, 5);
    }
    void Update()
    {
        if (!_type)
        {
            if(j == 0)
            {
                _invocType[0].SetActive(true);
                fee = 3;
                type = true;
            }
            if (j == 1)
            {
                _invocType[1].SetActive(true);
                fee = 4;
                type = true;
            }
            if (j == 2)
            {
                _invocType[2].SetActive(true);
                fee = 5;
                type = true;
            }
            if (j == 3)
            {
                _invocType[3].SetActive(true);
                fee = 2;
                type = false;
            }
            if (j == 4)
            {
                _invocType[4].SetActive(true);
                fee = 3;
                type = false;
            }
        }
        else
        {
            if (_chance == 0)
                type = true; fee = 2;
            if (_chance == 1)
                type = true; fee = 3;
            if (_chance == 2)
                type = false; fee = 1;
            if (_chance == 3)
                type = false; fee = 2;
            if (_chance == 4)
                type = false; fee = 3;
        }
    }
    public void Agree()
    {
        if (Player._materialPerStep >= fee && type)
        {
            if (!_type)
            {
                Player._repOfColony += 4;
            }
            else
            {
                Player._repOfSpirits += factorShaman;
            }
            Player._materialPerStep -= fee;
            CloseInvoc();
        }
        if (Player._foodPerStep >= fee && !type)
        {
            if (!_type)
            {
                Player._repOfColony += 4;
            }
            else
            {
                Player._repOfSpirits += factorShaman;
            }
            Player._foodPerStep -= fee;
            CloseInvoc();
        }
    }
    public void DisAgree()
    {
        if (!_type)
        {
            Player._repOfColony-= 4;
        }
        else
        {
            Player._repOfSpirits-= 4;
        }
        CloseInvoc();
    }
    public void CloseInvoc()
    {
        _invoc0.SetActive(false);
        _invoc1.SetActive(false);
    }
}

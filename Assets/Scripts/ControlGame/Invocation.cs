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
    static public int factorShaman = 1;
    [SerializeField] private bool type;

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
                _chance = Random.Range(0, 5);
                _invocation[i] = Instantiate(_invocType[_chance], transform.position, Quaternion.identity);
                _invocation[i].transform.SetParent(transform);
                _invocation[i].SetActive(false);
            }
        }
        else if (_type)
        {
            _count = 0;
            _chance = Random.Range(0, 5);
            _invocation[_count] = Instantiate(_invocType[_chance], transform.position, Quaternion.identity);
            _invocation[_count].transform.SetParent(transform);
        }
        j = Random.Range(0, 5);
    }
    void Update()
    {
        if (!_type)
        {
            if(j == 0)
            {
                _invocation[j].SetActive(true);
                fee = 0;
                type = false;
            }
            if (j == 1)
            {
                _invocation[j].SetActive(true);
                fee = 0;
                type = false;
            }
            if (j == 2)
            {
                _invocation[j].SetActive(true);
                fee = 0;
                type = false;
            }
            if (j == 3)
            {
                _invocation[j].SetActive(true);
                fee = 0;
                type = false;
            }
            if (j == 4)
            {
                _invocation[j].SetActive(true);
                fee = 0;
                type = false;
            }
        }
        else
        {
            fee = Random.Range(1, 5);
            type = Random.value < 0.5f;
        }
    }
    public void Agree()
    {
        if (!_type)
        {
            Player._repOfColony += 1;
        }
        else
        {
            Player._repOfSpirits += factorShaman;
        }
        if (type)
        {
            Player._materialPerStep -= fee;
        }
        else
        {
            Player._foodPerStep -= fee;
        }
    }
    public void DisAgree()
    {
        if (!_type)
        {
            Player._repOfColony--;
        }
        else
        {
            Player._repOfSpirits--;
        }
    }
}

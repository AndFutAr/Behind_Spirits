using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _speedCam = 5;
    public Transform target;
    public Vector3 offset;
    public Quaternion goSet;
    public float sensitivity = 3;
    public float limit = 80;
    private float X, Y;


    static public int _countPeople = 0, _placeForLive = 0, _foodPerStep = 0, _materialPerStep = 0, _ideasPerStep = 0, _repOfColony = 20, _repOfSpirits = 20;
    private int _needFood;
    [SerializeField] private Text _countText, _placeText, _foodText, _matText, _ideaText, _repSpirit, _repCol, _stepText, _needFoodText, _needPeopleText;
    [SerializeField] private GameObject _spiritNormal, _spiritNotNormal;

    static public int _thisStep = 0;
    static public bool isStep = false;
    private float t = 1;
    private bool _isSurvave = true, _isErr = false;
    static public bool isVozhd = false, isShaman = false;

    [SerializeField] private GameObject _butFinish;

    void Start()
    {
        StartStep();

        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
    }
    void Update()
    {
        _countText.text = _countPeople.ToString();
        _placeText.text = _placeForLive.ToString();
        _foodText.text = _foodPerStep.ToString();
        _matText.text = _materialPerStep.ToString();
        _ideaText.text = _ideasPerStep.ToString();
        _repCol.text = _repOfColony.ToString();
        _repSpirit.text = _repOfSpirits.ToString();
        _stepText.text = _thisStep.ToString();
        _needFoodText.text = _needFood.ToString();

        if (_thisStep % 3 == 0)
        {
            _needPeopleText.text = ((_thisStep / 3) * 2 + 2).ToString();
        }
        else if ((_thisStep + 1) % 3 == 0)
        {
            _needPeopleText.text = (((_thisStep + 1) / 3) * 2 + 2).ToString();
        }
        else if ((_thisStep + 2) % 3 == 0)
        {
            _needPeopleText.text = (((_thisStep + 2) / 3) * 2 + 2).ToString();
        }

        if (isStep)
        {
            _butFinish.SetActive(true);
        }
        else
        {
            _butFinish.SetActive(false);
            t -= Time.deltaTime;

            if (_isSurvave == true && t <= 0)
            {
                StartStep();
            }
            else
            {
                isStep = false;
            }
        }
        if (isStep)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += gameObject.transform.forward * _speedCam * Time.deltaTime;
                goSet = gameObject.transform.rotation;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position -= gameObject.transform.forward * _speedCam * Time.deltaTime;
                goSet = gameObject.transform.rotation;
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position -= gameObject.transform.right * _speedCam * Time.deltaTime;
                goSet = gameObject.transform.rotation;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += gameObject.transform.right * _speedCam * Time.deltaTime;
                goSet = gameObject.transform.rotation;
            }

            else if (Input.GetMouseButton(2))
            {
                X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
                Y += Input.GetAxis("Mouse Y") * sensitivity;
                Y = Mathf.Clamp(Y, -limit, limit);
                transform.localEulerAngles = new Vector3(-Y, X, 0);
                transform.position = transform.localRotation * offset + target.position;
            }

            if (Camera.main.fieldOfView >= 40 && Camera.main.fieldOfView <= 100)
            {
                Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10;
            }
            if(Camera.main.fieldOfView < 40)
            {
                Camera.main.fieldOfView = 40;
            }
            else if(Camera.main.fieldOfView > 100)
            {
                Camera.main.fieldOfView = 100;
            }
        }

        if ((_countPeople < ((_thisStep / 3) * 2 + 2) && _thisStep % 4 == 0 && _thisStep > 0) || _thisStep == 2 && _countPeople == 0)
        {
            _repOfColony = 0;
            _isErr = true;
            Debug.Log("where is your people");
        }
        /*if (_thisStep == 3 && isVozhd == false)
        {
            _repOfColony = 0;
            _isErr = true;
            Debug.Log("where is your vozhd");
        }*/
        if (_thisStep == 11 || _repOfColony <= 0 || _repOfSpirits <= 0 || !_isSurvave)
        {
            _thisStep = 0;
            isStep = false;
            Debug.Log("game over");

            if (!_isErr)
            {
                if (_repOfColony <= 0)
                {
                    Debug.Log("your colony closed");
                }
                if (_repOfSpirits <= 0)
                {
                    Debug.Log("your colony was destroed");
                }
            }
        }


        if(_repOfSpirits <= 5)
        {
            _spiritNormal.SetActive(false);
            _spiritNotNormal.SetActive(true);
        }
        else
        {
            _spiritNormal.SetActive(true);
            _spiritNotNormal.SetActive(false);
        }
    }
    public void StartStep()
    {
        _thisStep += 1;
        isStep = true;
        t = 1;
    }
    public void FinishStep()
    {
        SelectPoint._selectedPoint = null;  
        _needFood = _countPeople;
        isStep = false;
        _materialPerStep = 0;
        if (_foodPerStep >= _needFood)
        {
            _isSurvave = true;
        }
        else
        {
            _isSurvave = false;
            Debug.Log("your colony died");
        }
        _foodPerStep = 0;
    }
}


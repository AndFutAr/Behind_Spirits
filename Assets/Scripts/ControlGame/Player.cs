using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _speedCam = 5;
    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float limit = 80; // ограничение вращения по Y
    private float X, Y;


    static public int _countPeople = 0, _placeForLive = 0, _foodPerStep = 0, _materialPerStep = 0, _ideasPerStep = 0, _repOfColony = 20, _repOfSpirits = 20;
    private int _needFood;
    [SerializeField] private Text _countText, _placeText, _foodText, _matText, _ideaText, _repSpirit, _repCol, _stepText, _needFoodText;

    static public int _thisStep = 0;
    static public bool isStep = false;
    private float t = 1;
    private bool _isSurvave = false;

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
            }
            else if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position -= gameObject.transform.forward * _speedCam * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position -= gameObject.transform.right * _speedCam * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += gameObject.transform.right * _speedCam * Time.deltaTime;
            }

            Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10;

            if (Input.GetMouseButton(2))
            {
                X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
                Y += Input.GetAxis("Mouse Y") * sensitivity;
                Y = Mathf.Clamp(Y, -limit, limit);
                transform.localEulerAngles = new Vector3(-Y, X, 0);
                transform.position = transform.localRotation * offset + target.position;
            }
        }
        if (_thisStep == 11 || _repOfColony <= 0 || _repOfSpirits <= 0)
        {
            _thisStep = 10;
            isStep = false;
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
        if (SelectPoint._selectedPoint == null)
        {
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
            }
            _foodPerStep = 0;
        }
    }
}


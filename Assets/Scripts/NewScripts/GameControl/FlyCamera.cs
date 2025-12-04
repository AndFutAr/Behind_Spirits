using UnityEngine;

namespace NewScripts.MapControl
{
    public class FlyCamera : MonoBehaviour
    {
        private int _speedCam = 5;
        public Transform target;
        public Vector3 offset;
        public Quaternion goSet;
        public float sensitivity = 3;
        public float limit = 80;
        private float X, Y;
        
        void Start()
        {
            limit = Mathf.Abs(limit);
            if (limit > 90) limit = 90;
        }

        void Update()
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
        }
    }
}
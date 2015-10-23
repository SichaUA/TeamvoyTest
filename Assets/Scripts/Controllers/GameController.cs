using System.Collections.Generic;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public List<GameObject> Objects;
        public GameObject UiObjectInfo;

        private GameObject _currentObject;
        private Transform _uiObjParent;

        void Start()
        {
            Initialization();
        }

        void Initialization()
        {
            _uiObjParent = GameObject.FindGameObjectWithTag("UIObjectsParent").transform;

            InitializeUiList();
        }

        /// <summary>
        /// set new current object and destroy previous
        /// </summary>
        /// <param name="obj"></param>
        public void SetCurrObj(GameObject obj)
        {
            if (_currentObject != null)
            {
                Destroy(_currentObject);
            }

            _currentObject = (GameObject) Instantiate(obj, obj.transform.position, obj.transform.rotation);
        }

        /// <summary>
        /// Start animate object
        /// </summary>
        public void AnimateCurrentObj()
        {
            _currentObject.GetComponent<ModelController>().InverseAnimatorEnableStatus();
        }

        void InitializeUiList()
        {
            foreach (var obj in Objects)
            {
                CreateUiObject(obj.GetComponent<Object>());
            }
        }

        void CreateUiObject(Object objInfo)
        {
            GameObject uiObj = (GameObject) Instantiate(UiObjectInfo, UiObjectInfo.transform.position, UiObjectInfo.transform.rotation);
            //set parent
            uiObj.transform.parent = _uiObjParent;

            uiObj.GetComponent<UIObjectController>().SetObject(objInfo);
        }
    }
}
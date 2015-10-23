using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIObjectController : MonoBehaviour
    {
        private GameObject _objectToGenerate;
        private GameController _gameController;

        void Start()
        {
            Initialization();
        }

        void Initialization()
        {
            _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        /// <summary>
        /// set uiObject information(img, name) and model which will be generated on click
        /// </summary>
        /// <param name="obj"></param>
        public void SetObject(Object obj)
        {
            _objectToGenerate = obj.GameObject;

            transform.GetChild(0).GetComponent<Image>().sprite = obj.Image;
            transform.GetComponentInChildren<Text>().text = obj.Name;
        }

        /// <summary>
        /// Generate new model on click
        /// </summary>
        public void OnClick()
        {
            _gameController.SetCurrObj(_objectToGenerate);
        }
    }
}
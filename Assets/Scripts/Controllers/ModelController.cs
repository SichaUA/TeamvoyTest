using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ModelController : MonoBehaviour
    {
        private Animator _anim;

        void Start()
        {
            Initialization();

            _anim.enabled = false;
        }

        void Initialization()
        {
            _anim = GetComponent<Animator>();
        }

        /// <summary>
        /// inverse animator aneble status 
        /// </summary>
        public void InverseAnimatorEnableStatus()
        {
            _anim.enabled = !_anim.enabled;
        }
    }
}
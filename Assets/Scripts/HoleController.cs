using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class HoleController : MonoBehaviour
    {
        public bool isEmpty;

        // Use this for initialization
        void Start()
        {
            isEmpty = true;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            isEmpty = false;
        }

        private void OnTriggerExit(Collider other)
        {
            isEmpty = true;
        }
    }
}
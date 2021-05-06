using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Discrepancy
{
    [RequireComponent(typeof(Collider2D))]
    public class CheckableComponent : MonoBehaviour
    {
        public CheckableComponentType type;
        public Collider2D _componentCollider;
        public DiscrepancyManager _manager = null;

        [SerializeField] private bool _isRegistered = false;

        private Color _defaultColor;

        private void Awake()
        {
            _componentCollider = GetComponent<Collider2D>();
        }

        private void Start()
        {
            _defaultColor = this.gameObject.GetComponent<Renderer>().material.color;
        }

        private void OnMouseDown()
        {
            Debug.Log("clicked");
            if(!_manager)
            {
                _manager = GameObject.FindObjectOfType<DiscrepancyManager>();
            }

            if(_isRegistered)
            {
                ResetComponent();
            } else
            {
                _isRegistered = true;
                this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                _manager?.RegisterComponent(this);
            }

        }

        public void ResetComponent()
        {
            _manager?.UnregisterComponent(this);
            _isRegistered = false;
            this.gameObject.GetComponent<Renderer>().material.color = _defaultColor;
        }


    }

    public enum CheckableComponentType
    {
        NONE,
        NAME,
        FACE,
    }
    
}


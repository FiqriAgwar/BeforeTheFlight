using UnityEngine;

namespace Document
{
    public class Draggable : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector2 _dragOrigin;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void OnMouseDrag()
        {
            var mousePosition = (Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition - _dragOrigin;
        }

        private void OnMouseDown()
        {
            _dragOrigin = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
    }
}
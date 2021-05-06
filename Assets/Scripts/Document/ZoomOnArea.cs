using UnityEngine;

namespace Document
{
    [RequireComponent(typeof(Collider2D))]
    public class ZoomOnArea : MonoBehaviour
    {
        [SerializeField] private Collider2D largeCollider;
        [SerializeField] private Collider2D smallCollider;

        [SerializeField] private GameObject largeObject;
        [SerializeField] private GameObject smallObject;

        public Collider2D zoomArea;

        private bool _isZoomed;

        private void Awake()
        {
            if (zoomArea != null)
            {
                Init();
            }
        }

        public void Init()
        {
            _isZoomed = zoomArea.bounds.Contains(gameObject.transform.position);

            smallCollider.enabled = !_isZoomed;
            largeCollider.enabled = _isZoomed;
            smallObject.SetActive(!_isZoomed);
            largeObject.SetActive(_isZoomed);
        }

        private void OnMouseUp()
        {
            smallCollider.enabled = !_isZoomed;
            largeCollider.enabled = _isZoomed;
        }

        private void Update()
        {
            _isZoomed = zoomArea.bounds.Contains(gameObject.transform.position);

            smallObject.SetActive(!_isZoomed);
            largeObject.SetActive(_isZoomed);
        }
    }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Document
{
    [Serializable]
    public struct SpawnBoundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    public class DocumentFactory : MonoBehaviour
    {
        [SerializeField] private Collider2D zoomArea;
        [SerializeField] private SpawnBoundary spawnBoundary;
        [SerializeField] private GameObject documentPrefab;

        public GameObject CreateDocument()
        {
            var spawnX = Random.Range(spawnBoundary.xMin, spawnBoundary.xMax);
            var spawnY = Random.Range(spawnBoundary.yMin, spawnBoundary.yMax);

            var document = Instantiate(documentPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
            var zoomHandler = document.GetComponent<ZoomOnArea>();
            zoomHandler.zoomArea = zoomArea;

            zoomHandler.Init();

            return document;
        }

        private void OnDrawGizmos()
        {
            var width = Mathf.Abs(spawnBoundary.xMax - spawnBoundary.xMin);
            var height = Mathf.Abs(spawnBoundary.yMax - spawnBoundary.yMin);
            var center = new Vector2(spawnBoundary.xMin + width / 2f, spawnBoundary.yMin + height / 2f);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(center, new Vector3(width, height, 1f));
        }
    }
}
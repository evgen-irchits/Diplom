using System;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

namespace Script.Card
{
    public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Canvas CanvasUI;
        private RectTransform _rectTransform;
        public bool active = false;
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("OnBeginD");
            
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnD");
            _rectTransform.anchoredPosition += eventData.delta / CanvasUI.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndD");
        }
    }
}


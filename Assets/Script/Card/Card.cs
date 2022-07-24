using System;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

namespace Script.Card
{
    public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        [SerializeField] private Canvas CanvasUI;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        public bool active = false;
        public int NN = 0;
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            //Debug.Log("OnBeginD");
            _canvasGroup.alpha = .6f;
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("OnD");
            _rectTransform.anchoredPosition += eventData.delta / CanvasUI.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("OnEndD");
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }
    }
}


using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Card
{
    public class ClearCard : MonoBehaviour , IDropHandler
    {
        public int NN = 0;
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}
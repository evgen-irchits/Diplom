using System;
using DG.Tweening;
using UnityEngine;

namespace Script.UI
{
    [Serializable]
    public abstract class UIView : MonoBehaviour
    {
        public abstract string ViewName { get; }

        protected void Initialize()
        {
            transform.localScale = Vector3.zero;
        }
   
        public Tweener Show()
        {
            gameObject.SetActive(true);
            return transform.DOBlendableScaleBy(new Vector3(1,1,1),.5f); //transform.DOScale(1f, .5f);
        }

        public Tweener Hide()
        {
            var tweener = transform.DOScale(0f, .5f);
            tweener.onComplete += () => gameObject.SetActive(false);

            return tweener;
        }
    }
}

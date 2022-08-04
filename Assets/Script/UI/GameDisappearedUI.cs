using System;
using DG.Tweening;
using Script.Core;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script.UI
{
    public class GameDisappearedUI : UIView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Image[] images;
        [SerializeField] private Image[] clearCard;
        [SerializeField] private Text timerText;
        public float timerStart = 6;
        private int timerStart2;
        private void Start()
        {

            Initialize();
            backButton.onClick.AddListener(() =>
            {
                for (int i = 0; i < images.Length; i++)
                {
                    closeCard();
                    timerStart = 6;
                }

                GetComponent<GameDisappearedUI>().StopAllCoroutines();
                GameContext.Instance.ShowView(nameof(GameDisappearedLavelUi));
            });
        }
        private void Update()
        {
            timerStart -= Time.deltaTime;
            timerStart2 = (int) Mathf.Round((float) Convert.ToDouble(timerStart));
            timerText.text = timerStart2.ToString();
            if (timerStart2 == 0)
            {
                timerText.text = "0";
                for (int i = 0; i < images.Length; i++)
                {
                    if (images[i].GetComponent<Card.Card>().active == true)
                    {
                        images[i].gameObject.transform.DOMove(new Vector3(Random.Range(90, 1700), 100 , 0), 0.01f);
                        images[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    }

                }
            }else if (timerStart2 <= 0) {timerText.text = "0";}
        
        }
        private void closeCard()
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(false);
                clearCard[i].gameObject.SetActive(false);
                images[i].GetComponent<Card.Card>().active = false;
                images[i].gameObject.transform.DOMove(new Vector3(0,0,0),0.1f);
                images[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        public override string ViewName => nameof(GameDisappearedUI);
    }
}
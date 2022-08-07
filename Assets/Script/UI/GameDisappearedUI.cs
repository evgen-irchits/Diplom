using System;
using DG.Tweening;
using Script.Core;
using Script.Service;
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
        [SerializeField] private Image[] newCard;
        [SerializeField] private ImageList imageList;
        [SerializeField] private Text timerText;
        public float timerStart = 6;
        private int timerStart2;
        private int active = 0;

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
                timerStart = -1;
                timerStart2 = -1;
                timerText.text = "0";
                for (int i = 0; i < images.Length; i++)
                {
                    if (images[i].GetComponent<Card.Card>().active == true)
                    {
                        active = i;
                    }
                }

                for (int i = 0; i < active + 1; i++)
                {
                    images[i].gameObject.transform
                        .DOMove(new Vector3(Random.Range(90, 1700), Random.Range(300, 1100), 0), 0.01f);
                    images[i].gameObject.transform.DOMove(
                        new Vector3(clearCard[i].gameObject.transform.position.x,
                            clearCard[i].gameObject.transform.position.y,
                            clearCard[i].gameObject.transform.position.z), 0.01f);
                }

                int[] m = new int[TempClass.image.Length];
                int x = 0;
                while (x < TempClass.image.Length)
                {
                    int temp = Random.Range(0, TempClass.image.Length);
                    if (m[temp] == 0)
                    {
                        m[temp] = x;
                        ++x;
                    }                
                }
                
                
                for (int i = 0; i < TempClass.image.Length; i++)
                {
                    images[i].gameObject.transform.DOMove(
                        new Vector3(clearCard[m[i]].gameObject.transform.position.x,
                                clearCard[m[i]].gameObject.transform.position.y,
                                clearCard[m[i]].gameObject.transform.position.z), 0.01f);
                }

                TempClass.disappeared = Random.Range(0, active);
                images[TempClass.disappeared].gameObject.transform.DOMove(new Vector3(Random.Range(90, 1700), 100, 0), 0.01f);
                images[TempClass.disappeared].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                for (int i = 0; i < newCard.Length; i++)
                {
                    int ii = Random.Range(0, imageList.images.Length);
                    if (TempClass.image[TempClass.disappeared] != ii)
                    {
                        newCard[i].GetComponent<Image>().sprite = imageList.images[ii];
                        newCard[i].gameObject.transform.DOMove(new Vector3(Random.Range(90, 1700), 100, 0), 0.01f);
                        newCard[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        newCard[i].gameObject.SetActive(true);
                    }
                }
            }
            else if (timerStart2 <= 0)
            {
                timerText.text = "0";
            }
        }

        private void closeCard()
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(false);
                clearCard[i].gameObject.SetActive(false);
                images[i].GetComponent<Card.Card>().active = false;
                images[i].gameObject.transform.DOMove(new Vector3(0, 0, 0), 0.1f);
                images[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        public override string ViewName => nameof(GameDisappearedUI);
    }
}
using DG.Tweening;
using Script.Card;
using Script.Core;
using Script.Models;
using Script.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

namespace Script.UI
{
    public class GameRowLavelUi : UIView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button[] buttonLavel;
        [SerializeField] private ImageSetting imageSetting;
        [SerializeField] private ImageList imageList;
        [SerializeField] private Image[] images;
        [SerializeField] private Image[] clearCard;
        [SerializeField] private GameRowUI gameRowUI;
        private RectTransform _rectTransform;
        private void Start()
        {
            Initialize();
            var pm = GameContext.Instance.SaveService.Load<SaverModel>();
            var rom = pm.row;
            for (int i = 0; i < buttonLavel.Length; i++)
            {
                var NLavel = i;
                //Debug.Log(NLavel);
                if (i < rom - 1)
                {
                    buttonLavel[i].GetComponent<Image>().sprite = imageSetting.images[0];
                }
                else if (i == rom - 1)
                {
                    buttonLavel[i].GetComponent<Image>().sprite = imageSetting.images[1];
                }
                else
                {
                    buttonLavel[i].GetComponent<Image>().sprite = imageSetting.images[2];
                }

                if (i <= rom - 1)
                    buttonLavel[i].onClick.AddListener(() =>
                    {
                        GameContext.Instance.ShowView(nameof(GameRowUI));
                        GameContext.Instance.Lave = NLavel;
                        gameRowUI.timerStart = 6;
                        gameRowUI.r = 36;
                        float p = 120, p1 = 120, p2 = 120;
                        decimal x = NLavel / 3;
                        x = Math.Truncate(x);
                        int x1 = Convert.ToInt32(x);
                        int[] image = new int[x1 + 3];
                        int maxNumbr = image[0];
                        for (int j = 0; j < x + 3; j++)
                        {
                            image[j] = Random.Range(0, imageList.images.Length - 6);
                            if (image[j] > maxNumbr) maxNumbr = image[j];
                        }

                        for (int j = 0; j < x + 3; j++)
                        {
                            for (int k = 0; k < image.Length; k++)
                            {
                                if (image[j] == image[k])
                                {
                                    image[k] = maxNumbr;
                                    maxNumbr++;
                                }
                            }
                            
                        }

                        for (int j = 0; j < x + 3; j++)
                        {
                            images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
                        }

                        wiev(x);
                    });
            }
            
            backButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(VariantGameUI));
            });

           
        }

        private void wiev(decimal x)
        {
            _rectTransform = GetComponent<RectTransform>();
            float y = _rectTransform.rect.height;
            float p = 120, p1 = 120, p2 = 120;
            for (int j = 0; j < x + 3; j++)
            {
                images[j].gameObject.SetActive(true);
                clearCard[j].gameObject.SetActive(true);
                images[j].GetComponent<Card.Card>().active = true;
                if (j <= 8)
                {
                    images[j].gameObject.transform.DOMove(new Vector3(p, y - 150), .9f);
                    clearCard[j].gameObject.transform.DOMove(new Vector3(p, y - 150), .9f);
                    p = p + 200;
                }
                else if (j > 8 && j <= 16)
                {
                    images[j].gameObject.transform.DOMove(new Vector3(p1, y - 350), .9f);
                    clearCard[j].gameObject.transform.DOMove(new Vector3(p1, y - 350), .9f);
                    p1 = p1 + 200;
                }
                else
                {
                    images[j].gameObject.transform.DOMove(new Vector3(p2, y - 550), .9f);
                    clearCard[j].gameObject.transform.DOMove(new Vector3(p2, y - 550), .9f);
                    p2 = p2 + 200;
                }
            }
        }
        
        public override string ViewName => nameof(GameRowLavelUi);
    }
}

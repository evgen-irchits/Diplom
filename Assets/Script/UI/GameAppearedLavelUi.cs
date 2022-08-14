using System;
using DG.Tweening;
using Script.Core;
using Script.Models;
using Script.Service;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script.UI
{
    public class GameAppearedLavelUi : UIView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button[] buttonLavel;
        [SerializeField] private ImageSetting imageSetting;
        [SerializeField] private ImageList imageList;
        [SerializeField] private Image[] images;
        [SerializeField] private Image[] clearCard;
        [SerializeField] private GameAppearedUI gameAppearedUI;
        private void Awake()
        {
            Initialize();
            var pm = GameContext.Instance.SaveService.Load<SaverModel>();
            var appeared = pm.appeared;
            for (int i = 0; i < buttonLavel.Length; i++)
            {
                
                var nLevel = i;

                if (i < appeared - 1)
                {
                    buttonLavel[i].GetComponent<Image>().sprite = imageSetting.images[0];
                }
                else if (i == appeared - 1)
                {
                    buttonLavel[i].GetComponent<Image>().sprite = imageSetting.images[1];
                }
                else
                {
                    buttonLavel[i].GetComponent<Image>().sprite = imageSetting.images[2];
                }

                if (i <= appeared - 1)
                    buttonLavel[i].onClick.AddListener(() =>
                    {
                        GameContext.Instance.ShowView(nameof(GameAppearedUI));
                        GameContext.Instance.Lave = nLevel;
                        gameAppearedUI.timerStart = 6;
                        gameAppearedUI.r = 36;
                        float p = 120, p1 = 120, p2 = 120;
                        decimal x = nLevel / 3;
                        x = Math.Truncate(x);
                        TempClass.Ncard = Convert.ToInt32(x);
                        int maxNumbr = TempClass.image[0];
                        for (int j = 0; j < x + 3; j++)
                        {
                            TempClass.image[j] = Random.Range(0, imageList.images.Length - 6);
                            if (TempClass.image[j] > maxNumbr) maxNumbr = TempClass.image[j];
                        }

                        for (int j = 0; j < x + 3; j++)
                        {
                            for (int k = 0; k < TempClass.image.Length; k++)
                            {
                                if (TempClass.image[j] == TempClass.image[k])
                                {
                                    TempClass.image[k] = maxNumbr;
                                    maxNumbr++;
                                }
                            }
                        }

                        for (int j = 0; j < x + 3; j++)
                        {
                            images[j].GetComponent<Image>().sprite = imageList.images[TempClass.image[j]];
                        }

                        wiev(x);
                    });
            }
            backButton.onClick.AddListener(() => { GameContext.Instance.ShowView(nameof(VariantGameUI)); });
        }
        
        private void wiev(decimal x)
        {
            float p = 120, p1 = 120, p2 = 120;
            for (int j = 0; j < x + 3; j++)
            {
                images[j].gameObject.SetActive(true);
                clearCard[j].gameObject.SetActive(true);
                images[j].GetComponent<Card.Card>().active = true;
                if (j <= 8)
                {
                    images[j].gameObject.transform.DOMove(new Vector3(p, 900), .9f);
                    clearCard[j].gameObject.transform.DOMove(new Vector3(p, 900), .9f);
                    p = p + 200;
                }
                else if (j > 8 && j <= 16)
                {
                    images[j].gameObject.transform.DOMove(new Vector3(p1, 690), .9f);
                    clearCard[j].gameObject.transform.DOMove(new Vector3(p1, 690), .9f);
                    p1 = p1 + 200;
                }
                else
                {
                    images[j].gameObject.transform.DOMove(new Vector3(p2, 480), .9f);
                    clearCard[j].gameObject.transform.DOMove(new Vector3(p2, 480), .9f);
                    p2 = p2 + 200;
                }
            }
        }
        public override string ViewName => nameof(GameAppearedLavelUi);
        
    }
}

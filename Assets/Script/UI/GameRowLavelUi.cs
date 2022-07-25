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

        private void Awake()
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
                if (i<= rom - 1 ) buttonLavel[i].onClick.AddListener(() =>
                {
                    GameContext.Instance.ShowView(nameof(GameRowUI));
                    GameContext.Instance.Lave = NLavel;
                    float p = 120, p1 = 120, p2 = 120;
                    decimal x = NLavel / 3;
                    x = Math.Truncate(x);
                    int x1 = Convert.ToInt32(x);
                    int[] image = new int[x1+3];
                    image[0] = Random.Range(0, 62);
                    for (int j = 0; j < x + 3; j++)
                    {
                        images[j].gameObject.SetActive(true);
                        clearCard[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        image[j] = Random.Range(0, 62);
                        if (j != 0)
                        {
                            if (image[j] != image[j - 1])
                                images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
                            else images[j].GetComponent<Image>().sprite = imageList.images[Random.Range(0, 62)];
                        }
                        else images[j].GetComponent<Image>().sprite = imageList.images[Random.Range(0, 62)];

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
                    
                });
            }
            
            backButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(VariantGameUI));
            });

           
        }
        
        public override string ViewName => nameof(GameRowLavelUi);
    }
}

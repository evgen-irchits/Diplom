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

       // [Inject] private CardPoll poll;
        private void Awake()
        {
            Initialize();
            //var card = poll.Spawn();
            var pm = GameContext.Instance.SaveService.Load<SaverModel>();
            Debug.Log(pm.row);
            var rom = pm.row;
            for (int i = 0; i < buttonLavel.Length; i++)
            {
                var i1 = i;
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
                    GameContext.Instance.Lave = i1;
                    float p = 120;
                    decimal x = i1 / 3;
                    x = Math.Truncate(x);
                    //Debug.Log(x);
                    for (int j = 0; j < x + 3; j++)
                    {
                        images[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        images[j].GetComponent<Image>().sprite = imageList.images[Random.Range(0, 62)];
                        images[j].gameObject.transform.DOMove(new Vector3(p, 865), .9f);
                        //var card = poll.Spawn();
                       // card.transform.DOMove(new Vector3(p, 865), 2f);
                        //card.GetComponent<Image>().sprite = imageList.images[Random.Range(0, 62)];
                        p = p + 220;
                        
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

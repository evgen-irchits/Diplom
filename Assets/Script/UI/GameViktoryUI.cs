using System;
using DG.Tweening;
using Script.Core;
using Script.Models;
using Script.Service;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script.UI
{
    public class GameViktoryUI : UIView
    {
        [SerializeField] public Button nextButton;
        [SerializeField] public Button menuButton;
        [SerializeField] public Button restartButton;
        [SerializeField] private Image[] images;
        [SerializeField] private Image[] clearCard;
        [SerializeField] private Image[] newCard;
        [SerializeField] private ImageList imageList;
        [SerializeField] private GameRowUI gameRowUI;
        [SerializeField] private GameDisappearedUI gameDisappearedUI;
        [SerializeField] private GameAppearedUI gameAppearedUI;
        private RectTransform _rectTransform;

        void Start()
        {
            Initialize();

            nextButton.onClick.AddListener(() =>
            {
                if (TempClass.variantGame == 1)
                {

                    GameContext.Instance.ShowView(nameof(GameRowUI));
                    GameContext.Instance.Lave = GameContext.Instance.Lave +1;
                    gameRowUI.timerStart = 6;
                    gameRowUI.r = 36;
                    var pm = GameContext.Instance.SaveService.Load<SaverModel>();
                    var rom = pm.row;
                    float p = 120, p1 = 120, p2 = 120;
                    decimal x = rom / 3;
                    x = Math.Truncate(x);
                    int x1 = Convert.ToInt32(x);
                    int[] image = new int[x1 + 3];
                    image[0] = Random.Range(0, 62);

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
                        _rectTransform = GetComponent<RectTransform>();
                        float y = _rectTransform.rect.height;
                        images[j].gameObject.SetActive(true);
                        clearCard[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
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

                if (TempClass.variantGame == 3)
                {
                    GameContext.Instance.ShowView(nameof(GameDisappearedUI));
                    GameContext.Instance.Lave = GameContext.Instance.Lave +1;
                    gameDisappearedUI.timerStart = 6;
                    gameDisappearedUI.r = 36;
                    var pm = GameContext.Instance.SaveService.Load<SaverModel>();
                    var disappeared = pm.disappeared;
                    float p = 120, p1 = 120, p2 = 120;
                    decimal x = disappeared / 3;
                    x = Math.Truncate(x);
                    int x1 = Convert.ToInt32(x);
                    int[] image = new int[x1 + 3];
                    image[0] = Random.Range(0, 62);

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
                        _rectTransform = GetComponent<RectTransform>();
                        float y = _rectTransform.rect.height;
                        images[j].gameObject.SetActive(true);
                        clearCard[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
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

            });
            menuButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(StartUI)));
            restartButton.onClick.AddListener(() =>
            {
                if (TempClass.variantGame == 1)
                {
                    GameContext.Instance.ShowView(nameof(GameRowUI));
                    gameRowUI.timerStart = 6;
                    gameRowUI.r = 36;
                    var rom = GameContext.Instance.Lave;
                    float p = 120, p1 = 120, p2 = 120;
                    decimal x = rom / 3;
                    x = Math.Truncate(x);
                    int x1 = Convert.ToInt32(x);
                    int[] image = new int[x1 + 3];
                    image[0] = Random.Range(0, 62);
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
                        _rectTransform = GetComponent<RectTransform>();
                        float y = _rectTransform.rect.height;
                        images[j].gameObject.SetActive(true);
                        clearCard[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
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
                
                if (TempClass.variantGame == 3)
                {
                    GameContext.Instance.ShowView(nameof(GameDisappearedUI));
                    gameDisappearedUI.timerStart = 6;
                    gameDisappearedUI.r = 36;
                    var disappeared = GameContext.Instance.Lave;
                    float p = 120, p1 = 120, p2 = 120;
                    decimal x = disappeared / 3;
                    x = Math.Truncate(x);
                    int x1 = Convert.ToInt32(x);
                    int[] image = new int[x1 + 3];
                    image[0] = Random.Range(0, 62);
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
                        _rectTransform = GetComponent<RectTransform>();
                        float y = _rectTransform.rect.height;
                        images[j].gameObject.SetActive(true);
                        clearCard[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
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
                
            });
        }
        public override string ViewName => nameof(GameViktoryUI);
    }
}
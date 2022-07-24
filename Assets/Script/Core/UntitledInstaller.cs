using Script.Card;
using UnityEngine;
using Zenject;

namespace Script.Core
{
    public class UntitledInstaller : MonoInstaller
    {
        [SerializeField] private Transform cardPoll;
        [SerializeField] private Card.Card prefabCard;
        [SerializeField] private Transform canvasCard;
        public override void InstallBindings()
        {
            //Container.Bind<Card>().FromComponentInNewPrefab(prefabCard).AsTransient();
            //Container.Bind<Card.Card>().FromComponentInNewPrefab(prefabCard).UnderTransform(canvasCard).AsTransient();
           /* Container.BindMemoryPool<Card.Card, CardPoll>()
                .WithInitialSize(50)
                .FromComponentInNewPrefab(prefabCard)
                .UnderTransform(cardPoll);*/
        }
    }
}
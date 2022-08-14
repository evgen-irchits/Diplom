using UnityEngine;
namespace Script
{
    [CreateAssetMenu(fileName = "ImageList", menuName = "ScriptableObjekt/ImageList", order = 0)]
    public class ImageList : ScriptableObject
    {
        public Sprite[] images;
    }
}
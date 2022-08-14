using UnityEngine;
namespace Script
{
    [CreateAssetMenu(fileName = "ImageSetting", menuName = "ScriptableObjekt/ImageSetting", order = 0)]
    public class ImageSetting : ScriptableObject
    {
        public Sprite[] images;
    }
}
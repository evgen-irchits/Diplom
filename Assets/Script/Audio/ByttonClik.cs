using UnityEngine;

namespace Script.Audio
{
    public class ByttonClik : MonoBehaviour
    {
        public AudioSource myfx;
        public AudioClip myClikStart;
        public AudioClip myClik;
        public AudioClip myClikBack;
        public AudioClip myClikSelect;

        public void ClickSourseStart()
        {
            myfx.PlayOneShot(myClikStart);
        }
        public void ClickSourse()
        {
            myfx.PlayOneShot(myClik);
        }
        public void ClickSourseBack()
        {
            myfx.PlayOneShot(myClikBack);
        }
        
        public void ClickSourseSelect()
        {
            myfx.PlayOneShot(myClikSelect);
        }

    }
}

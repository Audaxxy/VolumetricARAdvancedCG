using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    [RequireComponent(typeof(RawImage))]
    public class WebcamImage : MonoBehaviour
    {
        private WebCamTexture wct;
        private RawImage myImage;

        public string myTextKey;

        private void Awake()
        {
            wct = new WebCamTexture();
            myImage = GetComponent<RawImage>();
            myImage.texture = wct;
            wct.Play();
        }

        //private void OnEnable()
        //{
        //    wct.Play();
        //}

        public void ScreenSnip(RawImage target)
        {
            Texture2D t = null;
            for (int i = 0; i < TextureHolder.Instance.textures.Count; ++i)
            {
                if (TextureHolder.Instance.textures[i].key == myTextKey)
                {
                    t = TextureHolder.Instance.textures[i].tex;
                    break;
                }
            }

            if (t == null)
            {
                Debug.Log("INVALID KEY!");
                return;
            }

            if (t.width != wct.width || t.height != wct.height)
            {
                t.Resize(wct.width, wct.height);
            }

            t.SetPixels(wct.GetPixels());
            t.Apply();

            target.texture = t;
        }

		//private void OnDisable()
		//{
		//    wct.Stop();
		//}

		private void OnDestroy()
        {
            Debug.Log("ON DESTROY!");
            wct.Stop();
            Destroy(wct);
        }

    }
}
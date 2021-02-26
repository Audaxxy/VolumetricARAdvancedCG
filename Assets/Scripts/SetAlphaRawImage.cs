using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    [RequireComponent(typeof(RawImage))]
    public class SetAlphaRawImage : SetAlphaBase
    {
        private RawImage image;
        public RawImage myImage
        {
            get
            {
                if (image != null)
                    return image;
                return (image = GetComponent<RawImage>());
            }
        }

        public override Color GetColor()
        {
            return myImage.color;
        }

        public override void SetColor(Color c)
        {
            myImage.color = c;
        }
    }
}
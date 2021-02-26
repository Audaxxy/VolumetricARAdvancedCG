using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    [RequireComponent(typeof(Image))]
    public class SetAlphaImage : SetAlphaBase
    {
        private Image image;
        public Image myImage
        {
            get
            {
                if (image != null)
                    return image;
                return (image = GetComponent<Image>());
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
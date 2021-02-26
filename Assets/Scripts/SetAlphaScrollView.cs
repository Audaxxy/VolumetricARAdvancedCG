using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    [RequireComponent(typeof(ScrollRect), typeof(Image))]
    public class SetAlphaScrollView : SetAlphaBase
    {
        private bool initialVertical;
        private bool initialHorizontal;

        private ScrollRect scroll;
        public ScrollRect myScroll
        {
            get
            {
                if (scroll != null)
                    return scroll;
                return (scroll = GetComponent<ScrollRect>());
            }
        }

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

        protected override void Awake()
        {
            initialVertical = myScroll.vertical;
            initialHorizontal = myScroll.horizontal;

            base.Awake();
        }

        public override Color GetColor()
        {
            return myImage.color;
        }

        public override void SetColor(Color c)
        {
            myImage.color = c;

            myScroll.vertical = (c.a > 0) ? initialVertical : false;
            myScroll.horizontal = (c.a > 0) ? initialHorizontal : false;
        }
    }
}
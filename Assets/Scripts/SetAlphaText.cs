using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    [RequireComponent(typeof(Text))]
    public class SetAlphaText : SetAlphaBase
    {
        private Text text;
        public Text myText
        {
            get
            {
                if (text != null)
                    return text;
                return (text = GetComponent<Text>());
            }
        }

        public override Color GetColor()
        {
            return myText.color;
        }

        public override void SetColor(Color c)
        {
            text.color = c;
        }
    }
}
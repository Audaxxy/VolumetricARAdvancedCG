using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    [RequireComponent(typeof(Button))]
    public class SetAlphaButton : SetAlphaBase
    {
        private Button button;
        public Button myButton
        {
            get
            {
                if (button != null)
                    return button;
                return (button = GetComponent<Button>());
            }
        }

        public override Color GetColor()
        {
            return myButton.image.color;
        }

        public override void SetColor(Color c)
        {
            myButton.image.color = c;
            myButton.interactable = (c.a > 0);
        }
    }
}
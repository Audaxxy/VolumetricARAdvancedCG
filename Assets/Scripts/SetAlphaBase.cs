using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtistUI
{
    public abstract class SetAlphaBase : MonoBehaviour
    {
        protected virtual void Awake()
        {
            FadeAllChildrenScript facs = GetComponentInParent<FadeAllChildrenScript>();

            if (facs != null)
            {
                facs.AddAlphaChild(this);
            }
        }

        public abstract Color GetColor();

        public abstract void SetColor(Color c);
    }
}
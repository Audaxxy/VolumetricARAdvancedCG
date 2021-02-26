using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    public struct ImageColorShift
    {
        public ImageColorShift(SetAlphaBase alphaRef, Color originalColor)
        {
            this.alphaRef = alphaRef;
            this.originalColor = originalColor;
        }

        public SetAlphaBase alphaRef;
        public Color originalColor;
    }

    public class FadeAllChildrenScript : MonoBehaviour
    {
        public Color myColorViewport;
        public Gradient alphaSet;
        public float duration = 1f;
        public float delay = 0f;
        private float currentTime = 0f;
        private float delta = 0f;
        private List<ImageColorShift> childImages = new List<ImageColorShift>();
        private bool initialized = false;

        [SerializeField]
        private bool fadeComplete = false;

        [SerializeField]
        private FadeDirection fadeDirection = FadeDirection.FORWARD;

        public void SetFadeDirection(FadeDirection direction)
        {
            fadeDirection = direction;

            if (fadeDirection == FadeDirection.NONE)
            {
                fadeComplete = true;
            }
            else
            {
                fadeComplete = false;
            }
        }

        private void Init()
        {
            if (initialized)
                return;

            ResetTime();
            myColorViewport = alphaSet.Evaluate(0);

            initialized = true;
        }

        public void ResetTime()
        {
            currentTime = 0;

            delta = 0;

            myColorViewport = alphaSet.Evaluate(0);

            fadeComplete = false;

            foreach (ImageColorShift im in childImages)
            {
                im.alphaRef.SetColor(im.originalColor * myColorViewport);
            }
        }

        public void UpdateTime()
        {
            if (fadeComplete)
                return;

            if (fadeDirection == FadeDirection.FORWARD)
            {
                currentTime = Mathf.Clamp(currentTime + Time.deltaTime, 0, duration + delay);

                if (currentTime >= duration + delay)
                {
                    fadeComplete = true;
                }
            }
            else
            {
                currentTime = Mathf.Clamp(currentTime - Time.deltaTime, 0, duration + delay);

                if (currentTime <= 0)
                {
                    fadeComplete = true;
                }
            }

            delta = Mathf.Max(0, currentTime - delay);

            myColorViewport = alphaSet.Evaluate(delta / duration);
        }

        public void AddAlphaChild(SetAlphaBase im)
        {
            Init();

            childImages.Add(new ImageColorShift(im, im.GetColor()));
            im.SetColor(myColorViewport);
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTime();

            foreach (ImageColorShift im in childImages)
            {
                im.alphaRef.SetColor(im.originalColor * myColorViewport);
            }
        }

        private void OnDestroy()
        {
            if (childImages.Count > 0)
            {
                childImages.Clear();
            }
        }
    }

    public enum FadeDirection
    {
        NONE,
        FORWARD,
        BACKWARD
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    public class FadeOperation
    {
        public FadeOperation(FadeDirection fadeDirection, float duration)
        {
            _fadeDirection = fadeDirection;
            this.duration = duration;
        }
        private FadeDirection _fadeDirection;
        public FadeDirection fadeDirection
        {
            get { return _fadeDirection; }
        }
        public float duration;
        public float elapsedTime = 0f;
        public bool complete = false;
    }

    public Image img;
    public enum FadeDirection { FadeIn, FadeOut }

    private FadeOperation currentOperation;

    public FadeOperation SetFade(FadeDirection direction, float duration)
    {
        currentOperation = new FadeOperation(direction, duration);
        return currentOperation;
    }

    void Update()
    {
        if (currentOperation != null)
        {
            currentOperation.elapsedTime += Time.deltaTime;
            Color imgColor = img.color;
            switch (currentOperation.fadeDirection)
            {
                case FadeDirection.FadeIn:
                    imgColor.a = currentOperation.elapsedTime / currentOperation.duration;
                    break;

                case FadeDirection.FadeOut:
                    imgColor.a = 1 - currentOperation.elapsedTime / currentOperation.duration;
                    break;
            }
            img.color = imgColor;
            if (currentOperation.elapsedTime >= currentOperation.duration)
            {
                currentOperation.complete = true;
                currentOperation = null;
            }
        }
    }
}

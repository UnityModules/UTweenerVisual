using System;
using UnityEngine;
using UnityEngine.UI;

namespace UTweener.Visual.Types
{
    public class UTweenAlpha : UTweenType
    {
        public enum CompnentType { Graphic, SpriteRenderer, CanvasGroup}

        private float start;
        [field:SerializeField, Range(0, 1)] public float Target { private set; get; }
        [SerializeField] private CompnentType component;

        private Graphic graphicComponent;
        private CanvasGroup canvasGroupComponent;
        private SpriteRenderer sprComponent;

        protected override void Initializer() 
        {
            switch (component)
            {
                case CompnentType.Graphic:
                    graphicComponent = GetComponent<Graphic>();
                    break;
                case CompnentType.SpriteRenderer:
                    canvasGroupComponent = GetComponent<CanvasGroup>();
                    break;
                case CompnentType.CanvasGroup:
                    sprComponent = GetComponent<SpriteRenderer>();
                    break;
            }
        }

        public override void Play(Action onComplete) =>
            Play(Target, onComplete,false);

        public override void ReversePlay(Action onComplete) =>
            Play(start, onComplete,true);

        private void Play(float target, Action onComplete, bool reverse = false)
        {
            switch (component)
            {
                case CompnentType.Graphic:
                    Play(graphicComponent.TweenAlpha(target),onComplete,reverse);
                    break;
                case CompnentType.SpriteRenderer:
                    Play(sprComponent.TweenAlpha(target),onComplete,reverse);
                    break;
                case CompnentType.CanvasGroup:
                    Play(canvasGroupComponent.TweenAlpha(target),onComplete,reverse);
                    break;
            }
        }

        public void UpdateStartValue(float startValue) =>
            start = startValue;
    }
}
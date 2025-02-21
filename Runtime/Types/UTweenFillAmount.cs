using System;
using UnityEngine;
using UnityEngine.UI;

namespace UTweener.Visual.Types
{
    public class UTweenFillAmount : UTweenType
    {
        private float start;
        [SerializeField, Range(0, 1)] private float target;

        private Image imgComponent;

        protected override void Initializer() =>
            imgComponent = GetComponent<Image>();

        public override void Play(Action onComplete) =>
            Play(target, onComplete);

        public override void ReversePlay(Action onComplete) =>
            Play(start, onComplete);

        private void Play(float target, Action onComplete) =>
            imgComponent.TweenFillAmount(target).SetConfig(config.Get).OnComplete(onComplete).Resume();

        public void UpdateStartValue(float startValue) =>
            start = startValue;
    }
}

using System;
using UnityEngine;
using UTweener.Visual.Types;

namespace UTweener.Visual
{
    public class UTweenTransform : UTweenType
    {
        public enum TransformType { Move, Rotate, Scale,RectSize }

        private Transform tr;
        private RectTransform rectTransform;
        private Vector3 start;
        [SerializeField] private Space space;
        [SerializeField] private TransformType type;
        [SerializeField] private Vector3 target;
   
        protected override void Initializer() 
        {
            tr = transform;

            switch (type)
            {
                case TransformType.Move:
                    start = space == Space.Self ? tr.localPosition : tr.position;
                    break;
                case TransformType.Rotate:
                    start = space == Space.Self ? tr.localEulerAngles : tr.eulerAngles;
                    break;
                case TransformType.Scale:
                    start = tr.localScale;
                    break;
                case TransformType.RectSize:
                    rectTransform = GetComponent<RectTransform>();
                    start = rectTransform.sizeDelta;
                    break;
            }
        }

        public override void Play(Action onComplete) =>
            Play(target, onComplete);

        public override void ReversePlay(Action onComplete) =>
            Play(start, onComplete);

        public void Play(Vector3 target, Action onComplete)
        {
            UTween<Vector3> tween = null;

            switch (type)
            {
                case TransformType.Move:
                    tween = tr.TweenPosition(target, space, config.Duration);
                    break;
                case TransformType.Rotate:
                    tween = tr.TweenEulerAngles(target, space, config.Duration);
                    break;
                case TransformType.Scale:
                    tween = tr.TweenScale(target, config.Duration);
                    break;
                case TransformType.RectSize:
                    tween = rectTransform.TweenRectSize(target, config.Duration);
                    break;
                default:
                    break;
            }

            tween.SetConfig(config.Get)
            .SetEase(config.EaseAnimation)
            .SetPingPong(config.PingPong)
            .OnComplete(onComplete)
            .Resume();
        }

        public void SetTarget(Vector3 value) =>
            target = value;
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UTweener.Visual.Types
{
    public class UTweenColor : UTweenType
    {
        public enum ComponentType { Graphic , SpriteRenderer}

        private Color start;
        [field:SerializeField] public Color Target { private set; get; }
        [SerializeField] private ComponentType component;

        private Graphic graphicComponent;
        private SpriteRenderer sprComponent;

        protected override void Initializer()
        {
            switch (component)
            {
                case ComponentType.Graphic:
                    start = (graphicComponent = GetComponent<Graphic>()).color;
                    break;

                case ComponentType.SpriteRenderer:
                    start = (sprComponent = GetComponent<SpriteRenderer>()).color;
                    break;
            }
        }

        public override void Play(Action onComplete) =>
            Play(Target, onComplete);

        public override void ReversePlay(Action onComplete) =>
            Play(start, onComplete);

        private void Play(Color target, Action onComplete)
        {
            switch (component)
            {
                case ComponentType.Graphic:
                    graphicComponent.TweenColor(target,config.Duration).SetConfig(config.Get).OnComplete(onComplete).Resume();
                    break;

                case ComponentType.SpriteRenderer:
                    sprComponent.TweenColor(target, config.Duration).SetConfig(config.Get).OnComplete(onComplete).Resume();
                    break;
            }

        }
    }
}
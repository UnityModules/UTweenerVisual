using System;
using UnityEngine;

namespace UTweener.Visual.Types
{
    public abstract class UTweenType : MonoBehaviour
    {
        protected UTweenConfigCard config;

        public void Initialize(UTweenConfigCard config)
        {
            this.config = config;
            Initializer();
        }

        protected abstract void Initializer();

        public abstract void Play(Action onComplete = null);
        public abstract void ReversePlay(Action onComplete = null);

        protected void Play<T>(UTween<T> tweener, Action onComplete = null, bool reverse = false)
        {
            tweener.
            SetConfig(config.Get).
            OnComplete(onComplete);

            if (reverse)
                tweener.ReversePlay();
            else
                tweener.Play();
        }

        public static void Play<T>(UTween<T> tweener,UTweenConfigCard config)
        {
            tweener.SetDuration(config.Duration).
            SetTimeScale(config.TimeScale).
            Resume();
        }
    }
}
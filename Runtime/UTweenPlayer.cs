using System;
using UnityEngine;
using UTweener.Visual.Types;

namespace UTweener.Visual
{
    public class UTweenPlayer : MonoBehaviour
    {
        [SerializeField] private bool playOnEnable;
        [SerializeField] private UTweenConfigCard config;
        [field: SerializeField] public UTweenType[] Targets { private set; get; }
        public bool IsPlayed { protected set; get; }

        public event Action OnComplete;

        private bool isInitialized;

        public void Initialize()
        {
            if (isInitialized)
                return;

            for (int i = 0; i < Targets.Length; i++)
                Targets[i].Initialize(config);

            isInitialized = true;
        }

        private void Awake()
        {
            if (!isInitialized)
                Initialize();
        }

        protected void OnEnable()
        {
            if (playOnEnable)
                Play(null);
        }

        public virtual void Play(Action onComplete)
        {
            if(!isInitialized)
                Initialize();

            IsPlayed = true;
            int completeCounter = 0;

            for (int i = 0; i < Targets.Length; i++)
                Targets[i].Play(OnComplete);

            void OnComplete()
            {
                completeCounter++;
                if (completeCounter >= Targets.Length)
                    onComplete?.Invoke();
            }
        }
        public virtual void ReversePlay(Action onComplete)
        {
            if (!isInitialized)
                Initialize();

            IsPlayed = false;
            int completeCounter = 0;

            for (int i = 0; i < Targets.Length; i++)
                Targets[i].ReversePlay(OnComplete);
            
            void OnComplete()
            {
                completeCounter++;
                if (completeCounter >= Targets.Length)
                    onComplete?.Invoke();
            }
        }
        public virtual void ChangeState(Action onComplete)
        {
            if (IsPlayed)
                ReversePlay(onComplete);
            else
                Play(onComplete);
        }

       // public void Play(UTweenType tween, Action onComplete) =>
       //     UTweenType.Play(tween,)
    }
}
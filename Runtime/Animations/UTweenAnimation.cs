using System;
using UnityEngine;

namespace UTweener.Visual
{
    public class UTweenAnimation : MonoBehaviour
    {
        public enum PlayType { Play, ReversePlay }

        [field:SerializeField] public PlayType Type { private set; get; }
        [SerializeField] private UTweenPlayer[] players;

        public void PlayDefault(Action onComplete = null)
        {
            switch (Type)
            {
                case PlayType.Play:
                    Play(onComplete);
                    break;
                case PlayType.ReversePlay:
                    ReversePlay(onComplete);
                    break;
            }
        }

        public void Play(Action onComplete = null)
        {
            for (int i = 0; i < players.Length; i++)
                players[i].Play(onComplete);
        }

        public void ReversePlay(Action onComplete = null)
        {
            for (int i = 0; i < players.Length; i++)
                players[i].ReversePlay(onComplete);
        }
    }
}
using System;
using UnityEngine;

namespace UTweener.Visual
{
    public class UTweenAnimator : MonoBehaviour
    {
        [field:SerializeField] public string DefaultState { private set; get; }
        [field:SerializeField] public UTweenAnimation[] States { private set; get; }

        private void OnEnable()
        {
            if (!string.IsNullOrEmpty(DefaultState))
                Play(DefaultState);
        }

        public void Play(string name,Action onComplete = null)
        {
            for (int i = 0; i < States.Length; i++)
                if (States[i].name == name)
                {
                    States[i].PlayDefault(onComplete);
                    break;
                }
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                Play("Show");

            if (Input.GetKeyDown(KeyCode.H))
                Play("Hide");
        }
#endif
    }
}
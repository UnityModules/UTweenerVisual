using System;
using UnityEngine;

namespace UTweener.Visual
{
    [Serializable]
    public record UTweenPingPong 
    {
        [field: SerializeField] public int Count;
        [field: SerializeField] public float Delay;
    }
}

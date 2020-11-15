using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ObservableReference
{
    public class BoolObservableListener : MonoBehaviour
    {
        [Serializable] private class BoolUnityEvent : UnityEvent<bool> { }
        [SerializeField] private BoolObservableReference reference = null;
        [SerializeField] private BoolUnityEvent onValue = null;

        private void OnEnable() => reference.Value.TakeUntilDisable(this).Subscribe(onValue.Invoke);
    }
}
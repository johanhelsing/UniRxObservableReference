using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ObservableReference
{
    public class StringObservableListener : MonoBehaviour
    {
        [Serializable] private class StringUnityEvent : UnityEvent<string> { }
        [SerializeField] private StringObservableReference reference = null;
        [SerializeField] private StringUnityEvent onValue = null;

        private void OnEnable() => reference.Value.TakeUntilDisable(this).Subscribe(onValue.Invoke);
    }
}

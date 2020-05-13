using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ObservableReference
{
    public class StringObservableListener : MonoBehaviour
    {
        private class StringUnityEvent : UnityEvent<string> { }
        [SerializeField] private StringObservableReference reference = null;
        [SerializeField] private StringUnityEvent onValue = null;

        private void OnEnable() => reference.Value.TakeUntilDisable(this).Subscribe(onValue.Invoke);
    }
}

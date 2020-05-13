using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ObservableReference
{
    public class IntObservableListener : MonoBehaviour
    {
        private class IntUnityEvent : UnityEvent<int> { }
        [SerializeField] private IntObservableReference reference = null;
        [SerializeField] private IntUnityEvent onValue = null;

        private void OnEnable() => reference.Value.TakeUntilDisable(this).Subscribe(onValue.Invoke);
    }
}

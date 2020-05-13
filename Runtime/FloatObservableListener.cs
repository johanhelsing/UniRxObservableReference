using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ObservableReference
{
    public class FloatObservableListener : MonoBehaviour
    {
        private class FloatUnityEvent : UnityEvent<float> { }

        [SerializeField] private FloatObservableReference reference = null;
        [SerializeField] private FloatUnityEvent onValue = null;

        private void OnEnable() => reference.Value.TakeUntilDisable(this).Subscribe(onValue.Invoke);
    }
}
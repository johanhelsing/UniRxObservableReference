using System;
using UnityEngine;

namespace ObservableReference
{
    [Serializable]
    public class ObservableReferenceBase
    {
        public virtual Type ObservableType => null;
    }

    [Serializable]
    public class ObservableReference<T> : ObservableReferenceBase
    {
        public override Type ObservableType => typeof(IObservable<T>);
        public MonoBehaviour behavior;
        public string propertyName;
    
        // TODO: support formerlySerializedAsAttribute
        // TODO: cache resolved property?
        public IObservable<T> Value => (IObservable<T>)behavior.GetType().GetProperty(propertyName)?.GetValue(behavior);
    }

    [Serializable]
    public class IntObservableReference : ObservableReference<int>
    {
    }

    [Serializable]
    public class FloatObservableReference : ObservableReference<float>
    {
    }

    [Serializable]
    public class StringObservableReference : ObservableReference<string>
    {
    }

    [Serializable]
    public class BoolObservableReference : ObservableReference<bool>
    {
    }
}
# UniRx Observable Reference

Adds types that can hold references to monobehavior properties implementing UniRX.IObservable.

Let's say you have the following class:

```c#
class HudViewModel : MonoBehaviour
{
    public IObservable<int> Score => score;
    [SerializedProperty] IntReactiveProperty score = new IntReactiveProperty(0);
}
```

with the `IntObservableReference`, in this package, you can now write the following:

```c#
class HudViewModel : MonoBehaviour
{
    [SerializedProperty] IntObservableReference scoreReference;
    private void Start()
    {
        scoreReference.Value.Subscribe(newScore => updateGui());
    }

    // ...
}
```

The `scoreReference` field can be edited in the inspector by picking a gameobject and a property through a menu.

I.e. the view doesn't have to know anything about the model, except that it has an int observable;

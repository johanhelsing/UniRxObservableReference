using System.Linq;
using UniRxObservableReference.Editor;
using UnityEditor;
using UnityEngine;

namespace ObservableReference.Editor
{
    [CustomPropertyDrawer(typeof(ObservableReferenceBase), true)]
    public class ObservableReferenceDrawer : PropertyDrawer
    {
        private SerializedProperty targetProperty;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += 3;
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            var behaviorProperty = property.FindPropertyRelative("behavior");
            var propertyNameProperty = property.FindPropertyRelative("propertyName");
            var observableType = ((ObservableReferenceBase)property.GetTargetObject()).ObservableType;
            EditorGUILayout.ObjectField(behaviorProperty);

            var behavior = (MonoBehaviour)behaviorProperty.objectReferenceValue;
            var propertyName = propertyNameProperty.stringValue;
            if (behavior != null)
            {
                var behaviors = behavior.GetComponents<MonoBehaviour>();
                var dropdownPosition = EditorGUILayout.GetControlRect();
                var currentProp = $"{behavior.GetType()}.{propertyName}";
                if (GUI.Button(dropdownPosition, currentProp, EditorStyles.popup))
                {
                    var menu = new GenericMenu();
                    var t = behavior.GetType();
                    var propsOnGameObject = behavior
                        .GetComponents<MonoBehaviour>()
                        .SelectMany(b => b.GetType().GetProperties(), (b, prop) => new {Behavior = b, Property = prop})
                        .Where(item => observableType.IsAssignableFrom(item.Property.PropertyType));
                    foreach (var item in propsOnGameObject)
                    {
                        menu.AddItem(new GUIContent($"{item.Behavior.GetType()}/{item.Property.Name}"), false, () => {
                            behaviorProperty.objectReferenceValue = item.Behavior;
                            propertyNameProperty.stringValue = item.Property.Name;
                            
                            behaviorProperty.serializedObject.ApplyModifiedProperties();
                            propertyNameProperty.serializedObject.ApplyModifiedProperties();
                        });
                    }
                    menu.DropDown(dropdownPosition);
                }
            }
            EditorGUI.EndProperty();
            EditorGUILayout.Space();
        }
    }
}
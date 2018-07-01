using UnityEditor;
using UnityEngine;

namespace UniCraft.Toolbox.Attribute
{
	public class DisableInInspector : PropertyAttribute
	{}

	[CustomPropertyDrawer(typeof(DisableInInspector))]
	public class DisableInInspectorDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginDisabledGroup(true);
			EditorGUI.PropertyField(position, property, label);
			EditorGUI.EndDisabledGroup();
		}
	}
}

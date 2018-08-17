using UnityEditor;
using UnityEngine;

namespace UniCraft.Toolbox.Attribute
{
	/// <inheritdoc/>
	/// <summary>
	/// Disable the flied in the inspector
	/// </summary>
	public class DisableInInspectorAttribute : PropertyAttribute
	{
	}

	[CustomPropertyDrawer(typeof(DisableInInspectorAttribute))]
	public class DisableInInspectorDrawer : PropertyDrawer
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginDisabledGroup(true);
			EditorGUI.PropertyField(position, property, label);
			EditorGUI.EndDisabledGroup();
		}
	}
}

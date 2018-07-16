using UniCraft.Toolbox.Class.Utility;
using UnityEditor;
using UnityEngine;

namespace UniCraft.Attribute
{
	/// <inheritdoc/>
	/// <summary>
	/// Disables the field in the inspector
	/// </summary>
	public class DisableInInspectorAttribute : PropertyAttribute
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		public readonly int IndentLevel;

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public DisableInInspectorAttribute(int indentLevel = -1)
		{
			IndentLevel = indentLevel;
		}
	}

	[CustomPropertyDrawer(typeof(DisableInInspectorAttribute))]
	public class DisableInInspectorDrawer : PropertyDrawer
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		private DisableInInspectorAttribute _disableInInspectorAttribute;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_disableInInspectorAttribute = attribute as DisableInInspectorAttribute;

			if (_disableInInspectorAttribute == null)
				return;
			EditorGUI.BeginDisabledGroup(true);
			EditorDrawerUtility.BeginIndentLevel(_disableInInspectorAttribute.IndentLevel);
			EditorGUI.PropertyField(position, property, label);
			EditorDrawerUtility.EndIndentLevel();
			EditorGUI.EndDisabledGroup();
		}
	}
}

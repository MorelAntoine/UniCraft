using UnityEditor;
using UnityEngine;

namespace UniCraft.Attribute
{
	/// <inheritdoc/>
	/// <summary>
	/// Indent the property by the given indent level
	/// </summary>
	public class IndentLevelAttribute : PropertyAttribute
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		public readonly int IndentLevel;

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public IndentLevelAttribute(int indentLevel)
		{
			IndentLevel = indentLevel;
		}
	}

	[CustomPropertyDrawer(typeof(IndentLevelAttribute))]
	public class IndentLevelDrawer : PropertyDrawer
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		private IndentLevelAttribute _indentLevelAttribute;
		private int _previousIndentLevel;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_indentLevelAttribute = attribute as IndentLevelAttribute;

			if (_indentLevelAttribute == null)
				return;
			_previousIndentLevel = EditorGUI.indentLevel;
			EditorGUI.indentLevel = _indentLevelAttribute.IndentLevel;
			EditorGUI.PropertyField(position, property, label);
			EditorGUI.indentLevel = _previousIndentLevel;
		}
	}
}

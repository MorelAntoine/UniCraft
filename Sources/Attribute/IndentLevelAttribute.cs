using UniCraft.Toolbox.Class.Utility;
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
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_indentLevelAttribute = attribute as IndentLevelAttribute;

			if (_indentLevelAttribute == null)
				return;
			EditorDrawerUtility.BeginIndentLevel(_indentLevelAttribute.IndentLevel);
			EditorGUI.PropertyField(position, property, label);
			EditorDrawerUtility.EndIndentLevel();
		}
	}
}

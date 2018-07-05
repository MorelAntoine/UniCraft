using UnityEditor;
using UnityEngine;

namespace UniCraft.Note.Editor
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Note))]
	public sealed class NoteEditor : UnityEditor.Editor
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		/////////////////////////////////////
		////////// Default setting //////////

		private const string AuthorLabel = "Made by:";
		private const float AuthorLabelWidth = 60f;
		private const float AuthorFieldWidth = 100f;
		private const float ColorFieldWidth = 16f;
		private const float ContentHeight = 150f;
		private const string ContentLabel = "Content";
		private const float ContentSpaceOffset = -10f;
		private const float SpaceBetweenField = 6f;
		private const float TitleFieldWidth = 160f;

		//////////////////////////////////
		////////// GUI resource //////////
		
		private bool _contentToggle;
		private readonly GUIContent _emptyGuiContent = new GUIContent("");
		
		/////////////////////////////////////////
		////////// Serialized property //////////
		
		private SerializedProperty _author;
		private SerializedProperty _content;
		private SerializedProperty _status;
		private SerializedProperty _title;

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		////////////////////////////////////////////
		////////// MonoBehaviour callback //////////
		
		private void OnEnable()
		{
			_author = serializedObject.FindProperty("Author");
			_content = serializedObject.FindProperty("Content");
			_status = serializedObject.FindProperty("Status");
			_title = serializedObject.FindProperty("Title");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			DrawTopInfo();
			DrawContent();
			DrawAuthor();
			serializedObject.ApplyModifiedProperties();
		}

		/////////////////////////////
		////////// Drawing //////////
		
		private void DrawAuthor()
		{
			GUILayout.Space(SpaceBetweenField);
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(AuthorLabel, GUILayout.Width(AuthorLabelWidth));
			_author.stringValue = EditorGUILayout.TextField(_author.stringValue, GUILayout.Width(AuthorFieldWidth));
			EditorGUILayout.EndHorizontal();
		}
		
		private void DrawContent()
		{
			GUILayout.Space(SpaceBetweenField);
			_contentToggle = EditorGUILayout.Foldout(_contentToggle, ContentLabel);
			if (!_contentToggle) return;
			GUILayout.Space(ContentSpaceOffset);
			EditorGUILayout.PropertyField(_content, _emptyGuiContent, GUILayout.Height(ContentHeight));
		}
		
		private void DrawTopInfo()
		{
			GUILayout.Space(SpaceBetweenField);
			EditorGUILayout.BeginHorizontal();
			_status.colorValue = EditorGUILayout.ColorField(_emptyGuiContent, _status.colorValue, false, false, false,
				GUILayout.Width(ColorFieldWidth));
			_title.stringValue = EditorGUILayout.TextField(_title.stringValue, GUILayout.Width(TitleFieldWidth));
			EditorGUILayout.EndHorizontal();
		}
	}
}

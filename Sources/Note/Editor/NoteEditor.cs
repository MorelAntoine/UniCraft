using UnityEditor;
using UnityEngine;

namespace UniCraft.Note.Editor
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Note))]
	public sealed class NoteEditor : UnityEditor.Editor
	{
		////////////////////////////////
		////////// Attributes //////////
		////////////////////////////////
		
		////////// Default settings //////////

		private const string AuthorLabel = "Made by:";
		private const float AuthorLabelWidth = 60f;
		private const float AuthorFieldWidth = 100f;
		private const float ColorFieldWidth = 16f;
		private const float ContentHeight = 150f;
		private const float ContentSpaceOffset = -10f;
		private const float SpaceBetweenField = 6f;
		private const float TitleFieldWidth = 160f;

		////////// GUI Contents //////////
		
		private readonly GUIContent _emptyGuiContent = new GUIContent("");
		
		////////// GUI Resources //////////
		
		private bool _contentToggle;
		
		////////// Serialized properties //////////
		
		private SerializedProperty _author;
		private SerializedProperty _content;
		private SerializedProperty _status;
		private SerializedProperty _title;

		/////////////////////////////
		////////// Methods //////////
		/////////////////////////////
		
		////////// Callbacks of MonoBehaviour //////////
		
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

		////////// Drawings //////////
		
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
			_contentToggle = EditorGUILayout.Foldout(_contentToggle, "Content");
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

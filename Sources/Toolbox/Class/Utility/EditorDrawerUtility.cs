using UnityEditor;

namespace UniCraft.Toolbox.Class.Utility
{
	public static class EditorDrawerUtility
	{
		private static int _previousIndentLevel;

		/// <summary>
		/// (if indentLevel is negative nothing happen) Saves the previous indent level and adjusts the indent level
		/// </summary>
		/// <param name="newIndentLevel">The new indent level</param>
		public static void BeginIndentLevel(int newIndentLevel)
		{
			if (newIndentLevel >= 0)
			{
				_previousIndentLevel = EditorGUI.indentLevel;
				EditorGUI.indentLevel = newIndentLevel;
			}
			else
				_previousIndentLevel = -1;
		}

		public static void EndIndentLevel()
		{
			if (_previousIndentLevel >= 0)
				EditorGUI.indentLevel = _previousIndentLevel;
		}
	}
}

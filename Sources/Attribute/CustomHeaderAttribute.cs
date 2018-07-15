using UnityEditor;
using UnityEngine;

namespace UniCraft.Attribute
{
    /// <inheritdoc/>
    /// <summary>
    /// Display a bold label with the given parameters
    /// </summary>
    public class CustomHeaderAttribute : PropertyAttribute
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        public readonly int IndentLevel;
        public readonly string Label;
        public readonly Vector2 LabelSize;
        public readonly float SpaceAfter;
        public readonly float SpaceBefore;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        public CustomHeaderAttribute(string label, int indentLevel = 0, float spaceBefore = 6f, float spaceAfter = 2.5f)
        {
            Label = label;
            LabelSize = EditorStyles.boldLabel.CalcSize(new GUIContent(Label));
            IndentLevel = indentLevel;
            SpaceAfter = spaceAfter;
            SpaceBefore = spaceBefore;
        }
    }

    [CustomPropertyDrawer(typeof(CustomHeaderAttribute))]
    public class CustomHeaderDrawer : DecoratorDrawer
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        /////////////////////////////////////
        ////////// Default Setting //////////

        private const float GuiHeight = 20f;
        private const float GuiStartY = 2f;
        private const float TmpSpaceAfter = 2.5f;
        private const float TmpSpaceBefore = 6f;
        
        //////////////////////////////
        ////////// Resource //////////

        private CustomHeaderAttribute _customHeaderAttribute;
        private int _previousIndentLevel;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        //////////////////////////////////////////////
        ////////// DecoratorDrawer Callback //////////
        
        public override float GetHeight()
        {
            if (_customHeaderAttribute != null)
                return (GuiHeight + GuiStartY + _customHeaderAttribute.SpaceAfter + _customHeaderAttribute.SpaceBefore);
            return (GuiHeight + GuiStartY + TmpSpaceAfter + TmpSpaceBefore);
        }
		
        public override void OnGUI(Rect position)
        {
            _customHeaderAttribute = attribute as CustomHeaderAttribute;

            if (_customHeaderAttribute == null)
                return;
            SetupIndentLevel();
            DrawCustomHeader(position);
            ResetIndentLevel();
        }
        
        /////////////////////////////
        ////////// Drawing //////////

        private void DrawCustomHeader(Rect guiPosition)
        {
            guiPosition.size.Set(_customHeaderAttribute.LabelSize.x, _customHeaderAttribute.LabelSize.y);
            guiPosition.y += GuiStartY + _customHeaderAttribute.SpaceBefore;
            EditorGUI.LabelField(guiPosition, _customHeaderAttribute.Label, EditorStyles.boldLabel);
        }
        
        /////////////////////////////
        ////////// Service //////////

        private void SetupIndentLevel()
        {
            _previousIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = _customHeaderAttribute.IndentLevel;
        }

        private void ResetIndentLevel()
        {
            EditorGUI.indentLevel = _previousIndentLevel;
        }
    }
}

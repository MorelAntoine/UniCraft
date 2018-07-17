using UnityEditor;
using UnityEngine;

namespace UniCraft.Attribute
{
	/// <inheritdoc/>
	/// <summary>
	/// Display a section header with the given parameters
	/// </summary>
	public class SectionHeaderAttribute : PropertyAttribute
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		public readonly string Label;
		public readonly Vector2 LabelSize;
		public readonly float SpaceAfter;
		public readonly float SpaceBefore;

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public SectionHeaderAttribute(string label, float spaceBefore = 5f, float spaceAfter = 8f)
		{
			Label = label;
			LabelSize = EditorStyles.boldLabel.CalcSize(new GUIContent(Label));
			SpaceAfter = spaceAfter;
			SpaceBefore = spaceBefore;
		}
	}

	[CustomPropertyDrawer(typeof(SectionHeaderAttribute))]
	public class HeaderSectionDrawer : DecoratorDrawer
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		/////////////////////////////////////
		////////// Default Setting //////////

		private const float GuiHeight = 4f;
		private const float GuiStartY = 10f;
		private const float AlignOffset = 8f;
		private const float LabelPadding = 4f;
		private const float TmpSpaceAfter = 8f;
		private const float TmpSpaceBefore = 5f;
		
		//////////////////////////////
		////////// Resource //////////

		private SectionHeaderAttribute _sectionHeaderAttribute;
		private float _labelFieldWidth;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		//////////////////////////////////////////////
		////////// DecoratorDrawer Callback //////////
		
		public override float GetHeight()
		{
			if (_sectionHeaderAttribute != null)
				return (GuiHeight + GuiStartY + _sectionHeaderAttribute.SpaceAfter + _sectionHeaderAttribute.SpaceBefore);
			return (GuiHeight + GuiStartY + TmpSpaceAfter + TmpSpaceBefore);
		}
		
		public override void OnGUI(Rect position)
		{
			_sectionHeaderAttribute = attribute as SectionHeaderAttribute;

			if (_sectionHeaderAttribute == null)
				return;
			if (_sectionHeaderAttribute.Label.Length == 0)
				DrawEmptyHeaderSection(position);
			else
				DrawHeaderSection(position);
		}
		
		/////////////////////////////
		////////// Drawing //////////

		private void DrawEmptyHeaderSection(Rect guiPosition)
		{
			guiPosition.height = 1f;
			guiPosition.y += GuiStartY + _sectionHeaderAttribute.SpaceBefore - AlignOffset;
			GUI.Box(guiPosition, "", GUI.skin.horizontalSlider);
		}

		private void DrawHeaderSection(Rect guiPosition)
		{
			_labelFieldWidth = (guiPosition.width - _sectionHeaderAttribute.LabelSize.x) / 2f;
			guiPosition.y += GuiStartY + _sectionHeaderAttribute.SpaceBefore - AlignOffset;
			
			guiPosition.Set(guiPosition.xMin, guiPosition.yMin, _labelFieldWidth, 1);
			GUI.Box(guiPosition, "", GUI.skin.horizontalSlider);
			
			guiPosition.Set(guiPosition.xMin + _labelFieldWidth + LabelPadding, guiPosition.yMin,
				_sectionHeaderAttribute.LabelSize.x, _sectionHeaderAttribute.LabelSize.y);
			GUI.Label(guiPosition, _sectionHeaderAttribute.Label, EditorStyles.boldLabel);

			guiPosition.Set(guiPosition.xMin + _sectionHeaderAttribute.LabelSize.x + LabelPadding,
				guiPosition.yMin, _labelFieldWidth - LabelPadding - LabelPadding, 1);
			GUI.Box(guiPosition, "", GUI.skin.horizontalSlider);
		}
	}
}

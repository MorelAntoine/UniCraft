using UnityEditor;
using UnityEngine;

namespace UniCraft.MaterialPatch.Editor
{
    [CustomEditor(typeof(MaterialPatch))]
    public class MatmaskEditor : UnityEditor.Editor
    {
        ////////////////////////////////
        ////////// Attributes //////////
        ////////////////////////////////
        
        ////////////////////////////////////
        ////////// Main Resources //////////

        [SerializeField] private MaterialPatch _materialPatch;
        
        ///////////////////////////////////
        ////////// GUI Resources //////////

        private int _toolbarIndex;
        private readonly string[] _toolbarLabels = { "General", "Color" };
        
        /////////////////////////////
        ////////// Methods //////////
        /////////////////////////////

        /////////////////////////////////////////
        ////////// Callbacks of Editor //////////

        private void OnEnable()
        {
            _materialPatch = target as MaterialPatch;
        }

        public override void OnInspectorGUI()
        {
            DrawToolbar();
            switch (_toolbarIndex)
            {
                default:
                    DrawGeneralPanel();
                    break;
                case 1:
                    DrawColorPanel();
                    break;
            }
        }
        
        //////////////////////////////
        ////////// Drawings //////////

        private void DrawToolbar()
        {
            _toolbarIndex = GUILayout.Toolbar(_toolbarIndex, _toolbarLabels);
        }
        
        ////////// Color //////////

        private void DrawColorPanel()
        {
            DrawLoadedColors();
            DrawInverseColorSection();
            DrawRandomColorSection();
            DrawManagementColorSection();
        }

        private void DrawLoadedColors()
        {
            //DrawUtility.DrawHeader("Loaded Colors");
            foreach (var rh in _materialPatch.RendererHelpers)
            {
                foreach (var m in rh.EditMaterials)
                    m.color = EditorGUILayout.ColorField(m.name, m.color, null);
            }
        }

        private void DrawInverseColorSection()
        {
            //DrawUtility.DrawHeader("Inverse");
            EditorGUI.BeginDisabledGroup(true);
            foreach (var rh in _materialPatch.RendererHelpers)
            {
                foreach (var m in rh.EditMaterials)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.ColorField(m.color);
                    //EditorGUILayout.ColorField(Toolbox.Utilities.ColorUtility.InvertColor(m.color));
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUI.EndDisabledGroup();
            if (GUILayout.Button("Invert Colors"))
                _materialPatch.InvertColors();
        }
        
        private void DrawRandomColorSection()
        {
            var minAlpha = _materialPatch.MinAlpha;
            var maxAlpha = _materialPatch.MaxAlpha;
            var minHue = _materialPatch.MinHue;
            var maxHue = _materialPatch.MaxHue;
            var minSaturation = _materialPatch.MinSaturation;
            var maxSaturation = _materialPatch.MaxSaturation;
            var minValue = _materialPatch.MinValue;
            var maxValue = _materialPatch.MaxValue;
            
            //DrawUtility.DrawHeader("Random");
            EditorGUILayout.MinMaxSlider("Alpha", ref minAlpha, ref maxAlpha, 0f, 1f, null);
            EditorGUILayout.MinMaxSlider("Hue", ref minHue, ref maxHue, 0f, 1f, null);
            EditorGUILayout.MinMaxSlider("Saturation", ref minSaturation, ref maxSaturation, 0f, 1f, null);
            EditorGUILayout.MinMaxSlider("Value", ref minValue, ref maxValue, 0f, 1f, null);
            _materialPatch.MinAlpha = minAlpha;
            _materialPatch.MaxAlpha = maxAlpha;
            _materialPatch.MinHue = minHue;
            _materialPatch.MaxHue = maxHue;
            _materialPatch.MinSaturation = minSaturation;
            _materialPatch.MaxSaturation = maxSaturation;
            _materialPatch.MinValue = minValue;
            _materialPatch.MaxValue = maxValue;
            if (GUILayout.Button("Randomize Colors"))
                _materialPatch.RandomizeColors();
        }

        private void DrawManagementColorSection()
        {
            //DrawUtility.DrawHeader("Management");
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Reset Colors"))
                _materialPatch.ResetColors();
            if (GUILayout.Button("Save Colors"))
                _materialPatch.SaveColors();
            EditorGUILayout.EndHorizontal();
        }
        
        ////////// General //////////

        private void DrawGeneralPanel()
        {
            DrawLoadedMaterials();
            DrawLoadSection();
            DrawPersistSection();
            DrawManagementSection();
        }

        private void DrawLoadedMaterials()
        {
            //DrawUtility.DrawHeader("Loaded Materials");
            EditorGUI.BeginDisabledGroup(true);
            foreach (var rh in _materialPatch.RendererHelpers)
            {
                foreach (var m in rh.EditMaterials)
                    EditorGUILayout.ObjectField(m, typeof(Material), false);
            }
            EditorGUI.EndDisabledGroup();
        }
        
        private void DrawLoadSection()
        {   
            //DrawUtility.DrawHeader("Loading Settings");
            _materialPatch.IncludeChildren = EditorGUILayout.ToggleLeft("Load Children ?", _materialPatch.IncludeChildren);
            _materialPatch.LoadMeshRenderer = EditorGUILayout.ToggleLeft("Load MeshRenderer ?", _materialPatch.LoadMeshRenderer);
            _materialPatch.LoadSkinnedMeshRenderer = EditorGUILayout.ToggleLeft("Load Load SkinnedMeshRenderer ?", _materialPatch.LoadSkinnedMeshRenderer);
            if (GUILayout.Button("Reload Materials"))
                _materialPatch.LoadRenderers();
        }

        private void DrawPersistSection()
        {
            //DrawUtility.DrawHeader("Persistence Settings");
            _materialPatch.PersistencePathname = EditorGUILayout.TextField(_materialPatch.PersistencePathname);
            if (GUILayout.Button("Persist Materials"))
                _materialPatch.PersistMaterials();
        }

        private void DrawManagementSection()
        {
            //DrawUtility.DrawHeader("Management");
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Reset Materials"))
                _materialPatch.ResetMaterials();
            if (GUILayout.Button("Save Materials"))
                _materialPatch.SaveMaterials();
            EditorGUILayout.EndHorizontal();
        }
    }
}
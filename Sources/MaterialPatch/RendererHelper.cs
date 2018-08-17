using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UniCraft.MaterialPatch
{
    /// <summary>
    /// Helper class used to handle a renderer more easily
    /// </summary>
    [System.Serializable]
    public class RendererHelper
    {
        ////////////////////////////////
        ////////// Attributes //////////
        ////////////////////////////////

        ////////////////////////////////////
        ////////// Main Resources //////////

        [SerializeField] private Renderer _renderer;

        ////////////////////////////////////
        ////////// Color settings //////////

        private string _colorFlag = "_Color";

        //////////////////////////////////////
        ////////// Default settings //////////

        private const string DefaultPersistencePathname = "Assets/";
        private const string EditMaterialPrefix = "[Edit] ";
        private const string MaterialExtensionName = ".mat";

        ///////////////////////////////
        ////////// Materials //////////

        [SerializeField] private Material[] _backupMaterials;
        [SerializeField] private List<Material> _editMaterials;

        ////////////////////////////////
        ////////// Properties //////////
        ////////////////////////////////

        ////////////////////////////////////
        ////////// Main Resources //////////

        public Renderer Renderer
        {
            get { return _renderer; }
        }
        
        ///////////////////////////////
        ////////// Materials //////////

        public Material[] BackupMaterials
        {
            get { return _backupMaterials; }
        }

        public IEnumerable<Material> EditMaterials
        {
            get { return _editMaterials; }
        }

        /////////////////////////////////
        ////////// Constructor //////////
        /////////////////////////////////

        public RendererHelper(Renderer renderer)
        {
            _renderer = renderer;
        }

        /////////////////////////////
        ////////// Methods //////////
        /////////////////////////////

        /////////////////////////
        ////////// API //////////

        ////////// Color //////////
        
        public void InvertColors()
        {
            //foreach (var m in _editMaterials)
            //    m.SetColor(_colorFlag, Utilities.ColorUtility.InvertColor(m.GetColor(_colorFlag)));
        }

        public void RandomizeColors(float minHue, float maxHue, float minSaturation, float maxSaturation,
            float minValue, float maxValue, float minAlpha, float maxAlpha)
        {
            foreach (var m in _editMaterials)
                m.SetColor(_colorFlag, Random.ColorHSV(minHue, maxHue, minSaturation, maxSaturation,
                    minValue, maxValue, minAlpha, maxAlpha));
        }

        public void ResetColors()
        {
            for (var i = 0; i < _backupMaterials.Length && i < _editMaterials.Count; i++)
                _editMaterials[i].SetColor(_colorFlag, _backupMaterials[i].GetColor(_colorFlag));
        }

        public void SaveColors()
        {
            for (var i = 0; i < _backupMaterials.Length && i < _editMaterials.Count; i++)
                _backupMaterials[i].SetColor(_colorFlag, _editMaterials[i].GetColor(_colorFlag));
        }

        ////////// Material //////////

        public void AttachEditMaterials()
        {
            _renderer.sharedMaterials = _editMaterials.ToArray();
        }

        public void CreateBackupMaterials()
        {
            _backupMaterials = _renderer.sharedMaterials;
        }

        public void CreateEditMaterials()
        {
            PrepareEditMaterialsList();
            for (var i = 0; i < _renderer.sharedMaterials.Length; i++)
            {
                _editMaterials.Add(new Material(_renderer.sharedMaterials[i]));
                _editMaterials[i].name = string.Concat(EditMaterialPrefix, _editMaterials[i].name);
            }
        }
        
        public void PersistMaterials(string pathname = DefaultPersistencePathname)
        {
            foreach (var m in _editMaterials)
                AssetDatabase.CreateAsset(new Material(m), Path.Combine(pathname, string.Concat(m.name, MaterialExtensionName)));
        }

        public void ResetMaterials()
        {
            for (var i = 0; i < _backupMaterials.Length && i < _editMaterials.Count; i++)
                CopyMaterial(_backupMaterials[i], _editMaterials[i]);
        }

        public void RestoreBackupMaterials()
        {
            _renderer.sharedMaterials = _backupMaterials;
        }

        public void SaveMaterials()
        {
            for (var i = 0; i < _backupMaterials.Length && i < _editMaterials.Count; i++)
                CopyMaterial(_editMaterials[i], _backupMaterials[i]);
        }

        //////////////////////////////
        ////////// Services //////////

        ////////// Initialization //////////

        private void PrepareEditMaterialsList()
        {
            if (_editMaterials == null)
                _editMaterials = new List<Material>(_renderer.sharedMaterials.Length);
            else
                _editMaterials.Clear();
        }

        ////////// Material //////////

        private static void CopyMaterial(Material src, Material dest)
        {
            dest.shader = src.shader;
            dest.shaderKeywords = src.shaderKeywords;
            dest.doubleSidedGI = src.doubleSidedGI;
            dest.enableInstancing = src.enableInstancing;
            dest.globalIlluminationFlags = src.globalIlluminationFlags;
            dest.mainTexture = src.mainTexture;
            dest.mainTextureOffset = src.mainTextureOffset;
            dest.mainTextureScale = src.mainTextureScale;
            dest.renderQueue = src.renderQueue;
            dest.color = src.color;
        }
    }
}
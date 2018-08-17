using System.Collections.Generic;
using UnityEngine;

namespace UniCraft.MaterialPatch
{
    /// <inheritdoc/>
    /// <summary>
    /// Component used to create and work on temporary materials
    /// </summary>
    [AddComponentMenu("UniCraft/MaterialPatch")]
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    public class MaterialPatch : MonoBehaviour
    {
        ////////////////////////////////
        ////////// Attributes //////////
        ////////////////////////////////

        ////////////////////////////////////
        ////////// Main Resources //////////

        [SerializeField] private List<RendererHelper> _rendererHelpers;
        
        ////////////////////////////////////
        ////////// Color Settings //////////
        
        ////////// Random //////////

        [SerializeField] private float _minAlpha;
        [SerializeField] private float _maxAlpha = 1f;
        [SerializeField] private float _minHue;
        [SerializeField] private float _maxHue = 1f;
        [SerializeField] private float _minSaturation ;
        [SerializeField] private float _maxSaturation = 1f;
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue = 1f;
        
        //////////////////////////////////////
        ////////// Loading Settings //////////

        [SerializeField] private bool _includeChildren = true;
        [SerializeField] private bool _loadMeshRenderer = true;
        [SerializeField] private bool _loadSkinnedMeshRenderer = true;
        
        //////////////////////////////////////////
        ////////// Persistence Settings //////////

        [SerializeField] private string _persistencePathname = "Assets/";
        
        ////////////////////////////////
        ////////// Properties //////////
        ////////////////////////////////

        ////////////////////////////////////
        ////////// Main Resources //////////

        public List<RendererHelper> RendererHelpers
        {
            get { return _rendererHelpers; }
        }
        
        ////////////////////////////////////
        ////////// Color Settings //////////
        
        ////////// Random //////////

        public float MinAlpha
        {
            get { return _minAlpha; }
            set { _minAlpha = value; }
        }

        public float MaxAlpha
        {
            get { return _maxAlpha; }
            set { _maxAlpha = value; }
        }

        public float MinHue
        {
            get { return _minHue; }
            set { _minHue = value; }
        }

        public float MaxHue
        {
            get { return _maxHue; }
            set { _maxHue = value; }
        }

        public float MinSaturation
        {
            get { return _minSaturation; }
            set { _minSaturation = value; }
        }

        public float MaxSaturation
        {
            get { return _maxSaturation; }
            set { _maxSaturation = value; }
        }

        public float MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }

        public float MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        //////////////////////////////////////
        ////////// Loading Settings //////////

        public bool IncludeChildren
        {
            get { return _includeChildren; }
            set { _includeChildren = value; }
        }

        public bool LoadMeshRenderer
        {
            get { return _loadMeshRenderer; }
            set { _loadMeshRenderer = value; }
        }

        public bool LoadSkinnedMeshRenderer
        {
            get { return _loadSkinnedMeshRenderer; }
            set { _loadSkinnedMeshRenderer = value; }
        }

        //////////////////////////////////////////
        ////////// Persistence Settings //////////

        public string PersistencePathname
        {
            get { return _persistencePathname; }
            set { _persistencePathname = value; }
        }

        /////////////////////////////
        ////////// Methods //////////
        /////////////////////////////
        
        //////////////////////////
        ////////// API //////////
        
        ////////// Color //////////

        public void InvertColors()
        {
            foreach (var rh in _rendererHelpers)
                rh.InvertColors();
        }

        public void RandomizeColors()
        {
            foreach (var rh in _rendererHelpers)
                rh.RandomizeColors(_minHue, _maxHue, _minSaturation, _maxSaturation, _minValue, _maxValue, _minAlpha, _maxAlpha);
        }

        public void ResetColors()
        {
            foreach (var rh in _rendererHelpers)
                rh.ResetColors();
        }

        public void SaveColors()
        {
            foreach (var rh in _rendererHelpers)
                rh.SaveColors();
        }
        
        ////////// Material //////////

        public void PersistMaterials()
        {
            foreach (var rh in _rendererHelpers)
                rh.PersistMaterials(_persistencePathname);
        }

        public void ResetMaterials()
        {
            foreach (var rh in _rendererHelpers)
                rh.ResetMaterials();
        }

        public void SaveMaterials()
        {
            foreach (var rh in _rendererHelpers)
                rh.SaveMaterials();
        }
        
        ////////// Renderer //////////

        public void LoadRenderers()
        {
            PrepareRendererHelpersList();
            if (_loadMeshRenderer)
                LoadRendererHelpers<MeshRenderer>();
            if (_loadSkinnedMeshRenderer)
                LoadRendererHelpers<SkinnedMeshRenderer>();
            CreateBackupsMaterials();
            CreateEditsMaterials();
            AttachEditsMaterials();
        }
        
        ////////////////////////////////////////////////
        ////////// Callbacks of MonoBehaviour //////////

        private void Awake()
        {
            if (_rendererHelpers == null)
                LoadRenderers();
        }

        private void OnApplicationQuit()
        {
            if (_rendererHelpers != null)
                RestoreBackupsMaterials();
        }

        private void OnDestroy()
        {
            if (_rendererHelpers != null)
                RestoreBackupsMaterials();
        }

        private void OnDisable()
        {
            if (_rendererHelpers != null)
                RestoreBackupsMaterials();
        }

        private void OnEnable()
        {
            if (_rendererHelpers != null)
                AttachEditsMaterials();
        }

        private void Reset()
        {
            if (_rendererHelpers != null)
                ResetColors();
        }

        //////////////////////////////
        ////////// Services //////////

        ////////// Initialization //////////

        private void PrepareRendererHelpersList()
        {
            if (_rendererHelpers == null)
                _rendererHelpers = new List<RendererHelper>();
            else
            {
                RestoreBackupsMaterials();
                _rendererHelpers.Clear();   
            }
        }
        
        ////////// Material //////////
        
        private void AttachEditsMaterials()
        {
            foreach (var rh in _rendererHelpers)
                rh.AttachEditMaterials();
        }

        private void CreateBackupsMaterials()
        {
            foreach (var rh in _rendererHelpers)
                rh.CreateBackupMaterials();
        }

        private void CreateEditsMaterials()
        {
            foreach (var rh in _rendererHelpers)
                rh.CreateEditMaterials();
        }

        private void LoadRendererHelpers<T>() where T : Renderer
        {
            var renderers = _includeChildren ? GetComponentsInChildren<T>() : GetComponents<T>();

            foreach (var r in renderers)
                _rendererHelpers.Add(new RendererHelper(r));
        }
        
        private void RestoreBackupsMaterials()
        {
            foreach (var rh in _rendererHelpers)
                rh.RestoreBackupMaterials();
        }
    }
}

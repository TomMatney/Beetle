using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using Sirenix.OdinInspector.Editor;

public class ScriptableObjectFactory : OdinMenuEditorWindow
{
    protected class FactoryModeSettings
    {
        public System.Type baseType;
        public string assetCreatePath;
    }

    //private FactoryModeSettings abilityFactoryMode = new FactoryModeSettings()
    //{
    //    baseType = typeof(AbilityData),
    //    assetCreatePath = "/_Game/Data/Abilities/"
    //};

    private FactoryModeSettings itemFactoryMode = new FactoryModeSettings()
    {
        baseType = typeof(ItemData),
        assetCreatePath = "/_Game/Data/Items/"
    };

    private FactoryModeSettings itemActionFactoryMode = new FactoryModeSettings()
    {
        baseType = typeof(ItemAction),
        assetCreatePath = "/_Game/Data/Items/ItemActions/"
    };

    //private FactoryModeSettings levelDataFactoryMode = new FactoryModeSettings()
    //{
    //    baseType = typeof(LevelData),
    //    assetCreatePath = "/_Game/Data/Level/LevelData/"
    //};

    [MenuItem("Cogs/Scriptable Object Factory")]
    static void Init()
    {
        ScriptableObjectFactory window = (ScriptableObjectFactory)EditorWindow.GetWindow(typeof(ScriptableObjectFactory));
        window.Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Selection.SupportsMultiSelect = false;

        tree.Add("Items", new FactoryEditor(this, itemFactoryMode));
        //tree.Add("Abilities", new FactoryEditor(this, abilityFactoryMode));
        tree.Add("ItemActions", new FactoryEditor(this, itemActionFactoryMode));  
        //tree.Add("LevelData", new FactoryEditor(this, levelDataFactoryMode));  
        return tree;
    }

    protected class FactoryEditor
    {
        private ScriptableObjectFactory scriptableObjectFactory;
        private FactoryModeSettings factoryModeSettings;

        [SerializeField] public string scriptableObjectName;

        public List<System.Type> types = new List<System.Type>();

        [OnValueChanged("UpdateScriptableObjectName")]
        [ValueDropdown(valuesGetter:"GetTypesAsStrings")]
        public string selectedTypeName = "";

        List<string> typeStrings = new List<string>();

        public FactoryEditor(ScriptableObjectFactory scriptableObjectFactory, FactoryModeSettings factoryModeSettings)
        {
            this.scriptableObjectFactory = scriptableObjectFactory;
            this.factoryModeSettings = factoryModeSettings;
            GetSubTypes();
        }

        [Button(ButtonSizes.Medium)]
        public void CreateAsset()
        {
            System.Type selectedType = types[GetTypeIndexFromName(selectedTypeName)];
            var asset = ScriptableObject.CreateInstance(selectedType);

            string directoryPath = Application.dataPath + factoryModeSettings.assetCreatePath;
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
                Debug.LogWarning("Creating Directory: " + directoryPath);
            }

            string filePath = $"Assets{factoryModeSettings.assetCreatePath}{scriptableObjectName}.asset";
            var uniqueFilePath = AssetDatabase.GenerateUniqueAssetPath(filePath);
            AssetDatabase.CreateAsset(asset, uniqueFilePath);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }

        private int GetTypeIndexFromName(string typeName)
        {
            return typeStrings.FindIndex( (a)=> a==typeName );
        }

        private void GetSubTypes()
        {
            System.Type selectedBaseType = factoryModeSettings.baseType;
            foreach (System.Type type in
                Assembly.GetAssembly(selectedBaseType).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && 
                (myType.IsSubclassOf(selectedBaseType) || myType == selectedBaseType)))
            {
                types.Add(type);
            }

            if(types.Count == 0)
            {
                Debug.LogError($"No types found for: {selectedBaseType.ToString()}");
                return;
            }
            types.Sort((x, y) => x.ToString().CompareTo(y.ToString()));

            typeStrings.Clear();
            for (int i = 0; i < types.Count; i++)
            {
                typeStrings.Add(types[i].ToString());
            }

            selectedTypeName = typeStrings[0];
            UpdateScriptableObjectName();
        }

        private List<string> GetTypesAsStrings()
        {
            return typeStrings;
        }

        private void UpdateScriptableObjectName()
        {
            scriptableObjectName = selectedTypeName;
        }
    }
}
 
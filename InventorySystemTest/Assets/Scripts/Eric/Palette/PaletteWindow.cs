using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace WFC.Window
{
    public class PaletteWindow : EditorWindow
    {
        List<SerializedPaletteData> palettes = new List<SerializedPaletteData>();
        
        [MenuItem("Tools/Palette Window")]
        public static void ShowWindow()
        {
            var window = GetWindow<PaletteWindow>();
            window.titleContent = new GUIContent("WFC Palette Window");
            window.minSize = new Vector2(800, 600);
        }

        void OnEnable()
        {
            VisualTreeAsset original = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Eric/Palette/WFCPaletteWindow.uxml");
            TemplateContainer treeAsset = original.CloneTree();
            rootVisualElement.Add(treeAsset);

            StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Eric/Palette/PaletteWindowStyles.uss");
            rootVisualElement.styleSheets.Add(styleSheet);

            CreatePaletteList();
        }

        void CreatePaletteList()
        {
            CreateSerialzedPalettes();
            Button addBtn = rootVisualElement.Query<Button>("create-palette").First();
            addBtn.clicked -= Temp;
            addBtn.clicked += Temp;

            ListView listView = rootVisualElement.Query<ListView>("palette-list").First();
            listView.makeItem = () => new Label();
            listView.bindItem = (element, i) => (element as Label).text = palettes[i].data.name;

            listView.itemsSource = palettes;
            listView.itemHeight = 16;
            listView.selectionType = SelectionType.Single;


            listView.onSelectionChange += (enumerable) => {
                foreach (object it in enumerable) {
                    Box paletteInfoBox = rootVisualElement.Query<Box>("palette-info").First();
                    paletteInfoBox.Clear();

                    SerializedPaletteData paletteInfo = (SerializedPaletteData)it;

                    SerializedObject serializedPalette = new SerializedObject(paletteInfo);
                    SerializedProperty paletteProperty = serializedPalette.GetIterator();
                    paletteProperty.Next(true);

                    while (paletteProperty.NextVisible(false)) 
                    {
                        PropertyField prop = new PropertyField(paletteProperty);

                        prop.SetEnabled(paletteProperty.name != "m_Script");
                        prop.Bind(serializedPalette);
                        paletteInfoBox.Add(prop);
                    }
      
                    Button saveButton = new Button();
                    saveButton.clicked += Save;
                    saveButton.text = "Save";

                    paletteInfoBox.Add(saveButton);

     
                }
            };

        }

        void CreateSerialzedPalettes()
        {
            List<PaletteData> paletteData = SavePaletteData.LoadPalettes();
            palettes.Clear();

            foreach(PaletteData data in paletteData) {
                var instance = (SerializedPaletteData)CreateInstance(typeof(SerializedPaletteData));
                instance.data = data;
                palettes.Add(instance);
            }
        }


        void Temp()
        {
            PaletteData test = new PaletteData(9);
            SavePaletteData.SaveToJSON(test);
            CreatePaletteList();
        }

        void Save()
        {
            foreach (SerializedPaletteData data in palettes) {
                SavePaletteData.SaveToJSON(data.data);
            }
            CreatePaletteList();
        }

        void Remove(SerializedPaletteData data)
        {
            //palettes.Remove(data);

            Debug.Log(data);

            //CreatePaletteList();
        }
        //Box cardInfoBox = rootVisualElement.Query<Box>("card-info").First();
    }

}

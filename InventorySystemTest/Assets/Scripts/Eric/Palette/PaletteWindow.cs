using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace WPC.Window
{
    public class PaletteWindow : EditorWindow
    {
        List<PaletteData> palettes;


        [MenuItem("Tools/Palette Window")]
        public static void ShowWindow()
        {
            var window = GetWindow<PaletteWindow>();
            window.titleContent = new GUIContent("WPC Palette Window");
            window.minSize = new Vector2(800, 600);
        }

        void OnEnable()
        {
            VisualTreeAsset original = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Eric/Palette/WPCPaletteWindow.uxml");
            TemplateContainer treeAsset = original.CloneTree();
            rootVisualElement.Add(treeAsset);

            StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Eric/Palette/PaletteWindowStyles.uss");
            rootVisualElement.styleSheets.Add(styleSheet);

            CreatePaletteList();
            CreatePaletteView();
        }

        void CreatePaletteList()
        {
            Button addBtn = rootVisualElement.Query<Button>("create-palette").First();
            addBtn.clicked -= Temp;
            addBtn.clicked += Temp;

            palettes = SavePaletteData.LoadPalettes();

            ListView listView = rootVisualElement.Query<ListView>("palette-list").First();
            listView.makeItem = () => new Label();
            listView.bindItem = (element, i) => (element as Label).text = palettes[i].name;

            listView.itemsSource = palettes;
            listView.itemHeight = 16;
            listView.selectionType = SelectionType.Single;


            //listView.onSelectionChange += (enumerable) => {
            //    foreach (Object it in enumerable) {
            //        Box paletteInfoBOx = rootVisualElement.Query<Box>("card-info").First();
            //    }
            //}

        }

        void CreatePaletteView()
        {

        }

        void Temp()
        {
            PaletteData test = new PaletteData(9);
            SavePaletteData.SaveToJSON(test);
            CreatePaletteList();
        }
        //Box cardInfoBox = rootVisualElement.Query<Box>("card-info").First();
    }

}

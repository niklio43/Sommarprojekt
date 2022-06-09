using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SavePaletteData
{
    public static string path = $"{Application.persistentDataPath}/WFC/Palettes/";

    private static void CheckFolders()
    {
        string subpath = $"{Application.persistentDataPath}/WFC";

        if (!Directory.Exists(subpath)) {
            Directory.CreateDirectory(subpath);
        }

        subpath = $"{Application.persistentDataPath}/WFC/Palettes";

        if (!Directory.Exists(subpath)) {
            Directory.CreateDirectory(subpath);
        }
    }

    public static void SavePalette(PaletteData palette)
    {
        CheckFolders();

        string data = JsonUtility.ToJson(palette, true);
        File.WriteAllText($"{path}{palette.id}.json", data);

        Debug.Log($"Saved Palette: {palette.id}.json");
    }

    public static void DeletePalette(PaletteData palette)
    {
        File.Delete($"{path}{palette.id}.json");

        Debug.Log($"Deleted Palette: {palette.id}.json");
    }

    public static List<PaletteData> LoadPalettes()
    {
        CheckFolders();

        string[] files = Directory.GetFiles(path);
        List<PaletteData> palettes = new List<PaletteData>();

        foreach (string file in files) {
            var data = File.ReadAllText(file);
            var palette = JsonUtility.FromJson<PaletteData>(data);
            palettes.Add(palette);
        }

        return palettes;
    }
}
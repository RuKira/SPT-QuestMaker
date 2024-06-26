﻿using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;

namespace SPT_AllInOne;

public class Utils
{
    public static void test()
    {
        string jsonString = File.ReadAllText("quests.json");
        var jsp = new JsonParser();
        dynamic objects = jsp.Parse(jsonString);

        foreach (var k in objects.Keys)
            Console.WriteLine(objects[k]["QuestName"]);
    }

    public static List<Quest> readQuestsFile(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        var jsp = new JsonParser();
        dynamic objects = jsp.Parse(jsonString);

        List<Quest> quests = new List<Quest>();
        foreach (var k in objects.Keys)
            quests.Add(new Quest(objects[k]));
        return quests;
    }
    
    public static dynamic readLocaleFile(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        var jsp = new JsonParser();
        dynamic objects = jsp.Parse(jsonString);
        
        return objects;
    }
    
    public static string generateId()
    {
        // Create a 24 character long random ID for the quest
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var id = new string(Enumerable.Repeat(chars, 24).Select(s => s[random.Next(s.Length)]).ToArray());
        Console.WriteLine(id);
        return id;
    }
}
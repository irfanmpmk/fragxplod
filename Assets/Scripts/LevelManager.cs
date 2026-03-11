using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int totalLevels = 100;
    public List<Level> levels;

    private void Awake()
    {
        GenerateLevels();
    }

    private void GenerateLevels()
    {
        levels = new List<Level>();

        for (int i = 0; i < totalLevels; i++)
        {
            Level level = new Level();
            level.LevelNumber = i + 1;
            level.Difficulty = CalculateDifficulty(i);
            levels.Add(level);
        }
    }

    private float CalculateDifficulty(int levelIndex)
    {
        // Example of progressive difficulty: Increase difficulty by 10% per level
        return 1 + (levelIndex * 0.1f);
    }

    public Level GetLevel(int levelNumber)
    {
        if (levelNumber < 1 || levelNumber > totalLevels)
        {
            Debug.LogError("Level number out of range");
            return null;
        }
        return levels[levelNumber - 1];
    }
}

[System.Serializable]
public class Level
{
    public int LevelNumber;
    public float Difficulty;
}
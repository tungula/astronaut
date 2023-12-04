using Assets.Objects;
using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundGenerator : MonoBehaviour
{
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject rock5;

    public GameObject stone;
    public GameObject ground;
    public GameObject oxygen;

    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;

    public GameObject iron;

    void Start()
    {
        RoundGeneratorParameters.Objects = new Dictionary<char, GameObjectParameterModel>();

        RoundGeneratorParameters.Objects.Add('g', new GameObjectParameterModel() { Width = 25, Name = "ground", Go = ground });

        RoundGeneratorParameters.Objects.Add('l', new GameObjectParameterModel() { Width = 2, Name = "rock1", Go = rock1, HeightCorrection = -0.04f });
        RoundGeneratorParameters.Objects.Add('i', new GameObjectParameterModel() { Width = 2, Name = "rock2", Go = rock2, HeightCorrection = -0.04f });
        RoundGeneratorParameters.Objects.Add('t', new GameObjectParameterModel() { Width = 2, Name = "rock3", Go = rock3, HeightCorrection = -0.04f });
        RoundGeneratorParameters.Objects.Add('h', new GameObjectParameterModel() { Width = 2, Name = "rock4", Go = rock4, HeightCorrection = -0.08f });
        RoundGeneratorParameters.Objects.Add('m', new GameObjectParameterModel() { Width = 2, Name = "rock5", Go = rock5, HeightCorrection = -0.2f });

        RoundGeneratorParameters.Objects.Add('n', new GameObjectParameterModel() { Width = 1, Name = "oxygen", Go = oxygen });

        RoundGeneratorParameters.Objects.Add('q', new GameObjectParameterModel() { Width = 1, Name = "stone", Go = stone });

        RoundGeneratorParameters.Objects.Add('p', new GameObjectParameterModel() { Width = 1, Name = "enemy2", Go = enemy2 });
        RoundGeneratorParameters.Objects.Add('u', new GameObjectParameterModel() { Width = 1, Name = "enemy3", Go = enemy3 });
        RoundGeneratorParameters.Objects.Add('j', new GameObjectParameterModel() { Width = 1, Name = "enemy4", Go = enemy4 });
        RoundGeneratorParameters.Objects.Add('a', new GameObjectParameterModel() { Width = 1, Name = "enemy5", Go = enemy5 });
        RoundGeneratorParameters.Objects.Add('b', new GameObjectParameterModel() { Width = 1, Name = "enemy6", Go = enemy6 });

        RoundGeneratorParameters.Objects.Add('k', new GameObjectParameterModel() { Width = 1, Name = "iron", Go = iron });


        RoundGeneratorParameters.Generate();

        for (int i = 0; i < RoundGeneratorParameters.RoundHeight; i++)
        {
            for (int j = 0; j < RoundGeneratorParameters.RoundWidth; j++)
            {
                if (RoundGeneratorParameters.Round[i, j] != 'o')
                {
                    GameObjectParameterModel value = null;
                    if (RoundGeneratorParameters.Objects.TryGetValue(RoundGeneratorParameters.Round[i, j], out value))
                    {
                        int width = RoundGeneratorParameters.Objects[RoundGeneratorParameters.Round[i, j]].Width;

                        float n = j + (width / 2.0f) - 10f;                                                             //სიგანე
                        float k = RoundGeneratorParameters.Round.GetLength(0) - i - 5.5f + value.HeightCorrection;      //სიმაღლე

                        Instantiate(value.Go, new Vector3(n, k), Quaternion.identity);
                    }
                }
            }
        }
    }


    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}

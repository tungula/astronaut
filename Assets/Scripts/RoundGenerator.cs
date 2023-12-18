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

    public GameObject planet1;
    public GameObject planet2;
    public GameObject planet3;
    public GameObject planet4;
    public GameObject planet5;
    public GameObject planet6;
    public GameObject planet7;
    public GameObject planet8;

    public GameObject mountain1;
    public GameObject mountain2;
    public GameObject mountain3;

    void Start()
    {
        RoundGeneratorParameters.Objects = new Dictionary<char, GameObjectParameterModel>();
        RoundGeneratorParameters.StaticObjects = new Dictionary<char, GameObjectParameterModel>();

        RoundGeneratorParameters.Objects.Add('g', new GameObjectParameterModel() { Width = 25, Name = "ground", Go = ground });

        RoundGeneratorParameters.Objects.Add('l', new GameObjectParameterModel() { Width = 2, Name = "rock1", Go = rock1, HeightCorrection = -0.04f });
        RoundGeneratorParameters.Objects.Add('i', new GameObjectParameterModel() { Width = 2, Name = "rock2", Go = rock2, HeightCorrection = -0.04f });
        RoundGeneratorParameters.Objects.Add('t', new GameObjectParameterModel() { Width = 2, Name = "rock3", Go = rock3, HeightCorrection = -0.04f });
        RoundGeneratorParameters.Objects.Add('h', new GameObjectParameterModel() { Width = 2, Name = "rock4", Go = rock4, HeightCorrection = -0.08f });
        RoundGeneratorParameters.Objects.Add('m', new GameObjectParameterModel() { Width = 2, Name = "rock5", Go = rock5, HeightCorrection = -0.2f });

        RoundGeneratorParameters.Objects.Add('n', new GameObjectParameterModel() { Width = 1, Name = "oxygen", Go = oxygen, HeightCorrection = -0.3f });

        RoundGeneratorParameters.Objects.Add('q', new GameObjectParameterModel() { Width = 1, Name = "stone", Go = stone/*, Count = 50*/ });

        RoundGeneratorParameters.Objects.Add('p', new GameObjectParameterModel() { Width = 1, Name = "enemy2 - დრაკონი", Go = enemy2, PositionY = RoundGeneratorParameters.RoundHeight - 2, Count = 15 });
        RoundGeneratorParameters.Objects.Add('u', new GameObjectParameterModel() { Width = 1, Name = "enemy3 - მფრინავი დრაკონი", Go = enemy3, Count = 0 });
        RoundGeneratorParameters.Objects.Add('j', new GameObjectParameterModel() { Width = 1, Name = "enemy4 - მფრინავი ცეცხლიანი დრაკონი", Go = enemy4, Count = 0 });
        RoundGeneratorParameters.Objects.Add('a', new GameObjectParameterModel() { Width = 1, Name = "enemy5 - ობობა", Go = enemy5, Count = 0 });
        RoundGeneratorParameters.Objects.Add('b', new GameObjectParameterModel() { Width = 1, Name = "enemy6 - ჟელე", Go = enemy6, Count = 0 });

        RoundGeneratorParameters.Objects.Add('k', new GameObjectParameterModel() { Width = 1, Name = "iron", Go = iron });


        RoundGeneratorParameters.StaticObjects.Add('a', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet1 });
        RoundGeneratorParameters.StaticObjects.Add('b', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet2 });
        RoundGeneratorParameters.StaticObjects.Add('c', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet3 });
        RoundGeneratorParameters.StaticObjects.Add('d', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet4 });
        RoundGeneratorParameters.StaticObjects.Add('e', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet5 });
        RoundGeneratorParameters.StaticObjects.Add('f', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet6 });
        RoundGeneratorParameters.StaticObjects.Add('g', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet7 });
        RoundGeneratorParameters.StaticObjects.Add('h', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet8 });

        RoundGeneratorParameters.StaticObjects.Add('i', new GameObjectParameterModel() { Width = 3, Name = "mountain", Go = mountain1, HeightCorrection = 0.071f });
        RoundGeneratorParameters.StaticObjects.Add('j', new GameObjectParameterModel() { Width = 3, Name = "mountain", Go = mountain2, HeightCorrection = 0.169f });
        RoundGeneratorParameters.StaticObjects.Add('k', new GameObjectParameterModel() { Width = 3, Name = "mountain", Go = mountain3, HeightCorrection = 0.116f });

        RoundDefaultParams();

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

                if (RoundGeneratorParameters.RoundStaticObjects[i, j] != RoundGeneratorParameters.EmptySymbol)
                {
                    GameObjectParameterModel value = null;
                    if (RoundGeneratorParameters.StaticObjects.TryGetValue(RoundGeneratorParameters.RoundStaticObjects[i, j], out value))
                    {
                        int width = RoundGeneratorParameters.StaticObjects[RoundGeneratorParameters.RoundStaticObjects[i, j]].Width;

                        float n = j + (width / 2.0f) - 10f;                                                             //სიგანე
                        float k = RoundGeneratorParameters.RoundStaticObjects.GetLength(0) - i - 5.5f + value.HeightCorrection;      //სიმაღლე

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

    private void RoundDefaultParams()
    {
        Medium();
    }

    static private void Medium()
    {
        RoundGeneratorParameters.Objects['p'].Count = RoundGeneratorParameters.RoundWidth / 15;
        RoundGeneratorParameters.Objects['u'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['j'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['a'].Count = RoundGeneratorParameters.RoundWidth / 20;
        RoundGeneratorParameters.Objects['b'].Count = RoundGeneratorParameters.RoundWidth / 20;
    }
}

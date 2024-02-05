using Assets.Objects;
using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Enums;

public class RoundGenerator : MonoBehaviour
{
    public GameObject player;

    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject rock5;
    public GameObject rockParent;

    public GameObject stone;
    public GameObject stoneDisableJump;
    public GameObject stoneParent;
    public GameObject ground;
    public GameObject groundParent;
    public GameObject oxygen;
    public GameObject oxygenParent;

    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemyParent;

    public GameObject iron;
    public GameObject ironParent;

    public GameObject planet1;
    public GameObject planet2;
    public GameObject planet3;
    public GameObject planet4;
    public GameObject planet5;
    public GameObject planet6;
    public GameObject planet7;
    public GameObject planet8;
    public GameObject planetParent;

    public GameObject mountain1;
    public GameObject mountain2;
    public GameObject mountain3;
    public GameObject mountainParent;

    private RoundLevelEnum roundLevel = RoundLevelEnum.Easy;

    public Toggle toggleEasy;
    public Toggle toggleMedium;
    public Toggle toggleHard;

    PlayerMove pm;

    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        DetectLevel();

        Test();

        LoandRoundParams();

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

                        var go = Instantiate(value.Go, new Vector3(n, k), Quaternion.identity);

                        if (value.Parent != null) go.transform.SetParent(value.Parent.transform);
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

                        var go = Instantiate(value.Go, new Vector3(n, k), Quaternion.identity);
                        if (value.Parent != null) go.transform.SetParent(value.Parent.transform);
                    }
                }
            }
        }
    }


    public void RestartGame()
    {
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentSceneName);

        EventSystem.current.SetSelectedGameObject(null);

        foreach (Transform child in enemyParent.transform) Destroy(child.gameObject);
        foreach (Transform child in mountainParent.transform) Destroy(child.gameObject);
        foreach (Transform child in planetParent.transform) Destroy(child.gameObject);
        foreach (Transform child in ironParent.transform) Destroy(child.gameObject);
        foreach (Transform child in oxygenParent.transform) Destroy(child.gameObject);
        foreach (Transform child in groundParent.transform) Destroy(child.gameObject);
        foreach (Transform child in stoneParent.transform) Destroy(child.gameObject);
        foreach (Transform child in rockParent.transform) Destroy(child.gameObject);

        player.transform.position = new Vector3(-8.43f, -3.5f, 0);


        pm.life = 10;
        pm.scoreText.text = @"Life - " + pm.life;

        Start();
    }

    private void LoandRoundParams()
    {
        switch (roundLevel)
        {
            case RoundLevelEnum.Easy:
                Easy();
                break;
            case RoundLevelEnum.Medium:
                Medium();
                break;
            case RoundLevelEnum.Hard:
                Hard();
                break;
            case RoundLevelEnum.Custom:
                Custom();
                break;
        }
    }

    static private void Medium()
    {
        //Enemy
        RoundGeneratorParameters.Objects['p'].Count = RoundGeneratorParameters.RoundWidth / 15;
        RoundGeneratorParameters.Objects['u'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['j'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['a'].Count = RoundGeneratorParameters.RoundWidth / 20;
        RoundGeneratorParameters.Objects['b'].Count = RoundGeneratorParameters.RoundWidth / 20;
    }

    static private void Easy()
    {
        RoundGeneratorParameters.Objects['l'].Count = RoundGeneratorParameters.RoundWidth / 80;
        RoundGeneratorParameters.Objects['i'].Count = RoundGeneratorParameters.RoundWidth / 80;
        RoundGeneratorParameters.Objects['t'].Count = RoundGeneratorParameters.RoundWidth / 80;
        RoundGeneratorParameters.Objects['h'].Count = RoundGeneratorParameters.RoundWidth / 80;

        //Enemy
        RoundGeneratorParameters.Objects['p'].Count = RoundGeneratorParameters.RoundWidth / 60;
        RoundGeneratorParameters.Objects['u'].Count = RoundGeneratorParameters.RoundWidth / 90;
        RoundGeneratorParameters.Objects['j'].Count = RoundGeneratorParameters.RoundWidth / 100;
        RoundGeneratorParameters.Objects['a'].Count = RoundGeneratorParameters.RoundWidth / 70;
        RoundGeneratorParameters.Objects['b'].Count = RoundGeneratorParameters.RoundWidth / 60;
    }

    static private void Hard()
    {
        //Enemy
        RoundGeneratorParameters.Objects['p'].Count = RoundGeneratorParameters.RoundWidth / 15;
        RoundGeneratorParameters.Objects['u'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['j'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['a'].Count = RoundGeneratorParameters.RoundWidth / 20;
        RoundGeneratorParameters.Objects['b'].Count = RoundGeneratorParameters.RoundWidth / 20;
    }

    static private void Custom()
    {
        RoundGeneratorParameters.Objects['l'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['i'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['t'].Count = RoundGeneratorParameters.RoundWidth / 30;
        RoundGeneratorParameters.Objects['h'].Count = RoundGeneratorParameters.RoundWidth / 30;

        //Enemy
        RoundGeneratorParameters.Objects['p'].Count = RoundGeneratorParameters.RoundWidth / 50;
        RoundGeneratorParameters.Objects['u'].Count = RoundGeneratorParameters.RoundWidth / 80;
        RoundGeneratorParameters.Objects['j'].Count = RoundGeneratorParameters.RoundWidth / 90;
        RoundGeneratorParameters.Objects['a'].Count = RoundGeneratorParameters.RoundWidth / 60;
        RoundGeneratorParameters.Objects['b'].Count = RoundGeneratorParameters.RoundWidth / 50;
    }

    private void Test()
    {
        RoundGeneratorParameters.Objects = new Dictionary<char, GameObjectParameterModel>();
        RoundGeneratorParameters.StaticObjects = new Dictionary<char, GameObjectParameterModel>();

        RoundGeneratorParameters.Objects.Add('g', new GameObjectParameterModel() { Width = 25, Name = "ground", Go = ground, Parent = groundParent });

        RoundGeneratorParameters.Objects.Add('l', new GameObjectParameterModel() { Width = 2, Name = "rock1", Go = rock1, HeightCorrection = -0.04f, Parent = rockParent });
        RoundGeneratorParameters.Objects.Add('i', new GameObjectParameterModel() { Width = 2, Name = "rock2", Go = rock2, HeightCorrection = -0.04f, Parent = rockParent});
        RoundGeneratorParameters.Objects.Add('t', new GameObjectParameterModel() { Width = 2, Name = "rock3", Go = rock3, HeightCorrection = -0.04f, Parent = rockParent});
        RoundGeneratorParameters.Objects.Add('h', new GameObjectParameterModel() { Width = 2, Name = "rock4", Go = rock4, HeightCorrection = -0.08f, Parent = rockParent});
        RoundGeneratorParameters.Objects.Add('m', new GameObjectParameterModel() { Width = 2, Name = "rock5", Go = rock5, HeightCorrection = -0.2f, Parent = rockParent});

        RoundGeneratorParameters.Objects.Add('n', new GameObjectParameterModel() { Width = 1, Name = "oxygen", Go = oxygen, HeightCorrection = -0.3f, Parent = oxygenParent });

        RoundGeneratorParameters.Objects.Add('q', new GameObjectParameterModel() { Width = 1, Name = "stone", Go = stone, Parent = stoneParent });
        RoundGeneratorParameters.Objects.Add('z', new GameObjectParameterModel() { Width = 1, Name = "stoneDisableJump", Go = stone, Parent = stoneParent });

        RoundGeneratorParameters.Objects.Add('p', new GameObjectParameterModel() { Width = 1, Name = "enemy2 - დრაკონი", Go = enemy2, PositionY = RoundGeneratorParameters.RoundHeight - 2, Count = 15, Parent = enemyParent, HeightCorrection = -0.2f });
        RoundGeneratorParameters.Objects.Add('u', new GameObjectParameterModel() { Width = 1, Name = "enemy3 - მფრინავი დრაკონი", Go = enemy3, Count = 0, Parent = enemyParent, HeightCorrection = 0.6f });
        RoundGeneratorParameters.Objects.Add('j', new GameObjectParameterModel() { Width = 1, Name = "enemy4 - მფრინავი ცეცხლიანი დრაკონი", Go = enemy4, Count = 0, Parent = enemyParent, HeightCorrection = 0.6f });
        RoundGeneratorParameters.Objects.Add('a', new GameObjectParameterModel() { Width = 1, Name = "enemy5 - ობობა", Go = enemy5, Count = 0, Parent = enemyParent });
        RoundGeneratorParameters.Objects.Add('b', new GameObjectParameterModel() { Width = 1, Name = "enemy6 - ჟელე", Go = enemy6, Count = 0, Parent = enemyParent, HeightCorrection = -0.2f });

        RoundGeneratorParameters.Objects.Add('k', new GameObjectParameterModel() { Width = 1, Name = "iron", Go = iron, Parent = ironParent });


        RoundGeneratorParameters.StaticObjects.Add('a', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet1, Parent = planetParent });
        RoundGeneratorParameters.StaticObjects.Add('b', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet2, Parent = planetParent });
        RoundGeneratorParameters.StaticObjects.Add('c', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet3, Parent = planetParent });
        RoundGeneratorParameters.StaticObjects.Add('d', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet4, Parent = planetParent });
        RoundGeneratorParameters.StaticObjects.Add('e', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet5, Parent = planetParent });
        RoundGeneratorParameters.StaticObjects.Add('f', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet6, Parent = planetParent });
        RoundGeneratorParameters.StaticObjects.Add('g', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet7, Parent = planetParent });
        RoundGeneratorParameters.StaticObjects.Add('h', new GameObjectParameterModel() { Width = 1, Name = "planet", Go = planet8, Parent = planetParent });

        RoundGeneratorParameters.StaticObjects.Add('i', new GameObjectParameterModel() { Width = 3, Name = "mountain", Go = mountain1, HeightCorrection = 0.071f, Parent = mountainParent });
        RoundGeneratorParameters.StaticObjects.Add('j', new GameObjectParameterModel() { Width = 3, Name = "mountain", Go = mountain2, HeightCorrection = 0.169f, Parent = mountainParent });
        RoundGeneratorParameters.StaticObjects.Add('k', new GameObjectParameterModel() { Width = 3, Name = "mountain", Go = mountain3, HeightCorrection = 0.116f, Parent = mountainParent });
    }

    private void DetectLevel()
    {
        if (toggleEasy.isOn) roundLevel = RoundLevelEnum.Easy;
        if (toggleMedium.isOn) roundLevel = RoundLevelEnum.Medium;
        if (toggleHard.isOn) roundLevel = RoundLevelEnum.Hard;

#if UNITY_EDITOR
        roundLevel = RoundLevelEnum.Easy;
#endif
    }
}

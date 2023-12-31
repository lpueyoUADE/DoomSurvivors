﻿using System;
using System.Collections.Generic;

namespace DoomSurvivors
{
    public class SceneController
    {
        private static SceneController instance;

        private List<Scene> scenes;
        private int currentSceneIndex;
        private int nextSceneIndex;
        private bool reload;

        public Scene CurrentScene => scenes[currentSceneIndex];

        public static SceneController Instance
        {
            get {
                if (instance == null)
                {
                    instance = new SceneController();
                }

                return instance;
            }
        }
            
        private SceneController()
        {
            this.scenes = null;
            this.currentSceneIndex = 0;
            this.reload = true;
        }

        public void setScenes(List<Scene> sceneList)
        {
            this.scenes = sceneList;
        }
        public void ChangeScene(int nextSceneIndex)
        {
            if (nextSceneIndex < 0 || nextSceneIndex > scenes.Count)
                throw new ArgumentOutOfRangeException("Scene index out of bounds");

            this.nextSceneIndex = nextSceneIndex;
            reload = true;
        }

        public void NextLevel()
        {
            ChangeScene(currentSceneIndex + 1);
        }

        public void Load()
        {
            if (reload)
            {
                scenes[currentSceneIndex].UnLoad();
                currentSceneIndex = nextSceneIndex;
                scenes[currentSceneIndex].Load();
                reload = false;
            }
        }

        public void Update()
        {
            scenes[currentSceneIndex].Update();
        }

        public void Render()
        {
            scenes[currentSceneIndex].Render();
        }
    }
}

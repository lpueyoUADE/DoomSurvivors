using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors
{
    public class SceneController
    {
        private static SceneController instance;

        private List<Scene> scenes;
        private int currentSceneIndex;
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
        public void changeScene(int nextSceneIndex)
        {
            if (nextSceneIndex < 0 || nextSceneIndex > scenes.Count)
            {
                throw new ArgumentOutOfRangeException("Scene index out of bounds");
            }

            currentSceneIndex = nextSceneIndex;
            reload = true;   
        }

        public void Load()
        {
            if (reload)
            {
                scenes[currentSceneIndex].Load();
                reload = false;
            }
        }

        public void Update()
        {
            scenes[currentSceneIndex].Update();
        }
    }
}

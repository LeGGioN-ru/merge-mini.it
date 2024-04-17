using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniIT.UTILITY.SCENE
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private bool _isGameScene;
        [ShowIf("_isGameScene")][SerializeField] private GameType _gameType;

        public void LoadGameScene()
        {
            PlayerPrefs.SetInt(nameof(GameType), (int)_gameType);

            SceneManager.LoadScene(AppConstants.Scenes.GameScene);
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(AppConstants.Scenes.MenuScene);
        }
    }
}
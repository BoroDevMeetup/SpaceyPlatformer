using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement { 
	public class GameManager : MonoBehaviour {
		public static GameManager Current;
		private static SceneIndexes currentScene;

		private void Awake() {
			Current = this;

			GameEvents.Current.onLoadScene += LoadScene;

			GameEvents.Current.LoadScene(SceneIndexes.PLAY_SCENE);
		}

		private void OnDestroy() {
			GameEvents.Current.onLoadScene -= LoadScene;
		}

		public void LoadScene(SceneIndexes sceneIndex) {
			SceneManager.UnloadSceneAsync((int)currentScene);

			currentScene = sceneIndex;
			SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive);
		}
	}
}

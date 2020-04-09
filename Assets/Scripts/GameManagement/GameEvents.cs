using System;

namespace GameManagement { 
	public sealed class GameEvents {

		private static GameEvents current = null;
		private static readonly object padlock = new object();

		GameEvents() { }

		public static GameEvents Current {
			get {
				lock (padlock) {
					if (current == null) {
						current = new GameEvents();
					}
					return current;
				}
			}
		}

		/*******************************************************/
		/*****          Game Lifecycle Events             ****/
		/*******************************************************/
		public event Action<SceneIndexes> onLoadScene;
		public void LoadScene(SceneIndexes sceneIndex) {
			if (onLoadScene == null) return;

			onLoadScene(sceneIndex);
		}
	}
}

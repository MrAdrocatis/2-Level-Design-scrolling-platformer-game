using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        [Tooltip("The name of the next scene to load.")]
        public string nextSceneName;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;

                // Start the coroutine to load the next scene after a delay
                StartCoroutine(LoadNextSceneWithDelay());
            }
        }

        private System.Collections.IEnumerator LoadNextSceneWithDelay()
        {
            yield return new WaitForSeconds(5f); // Wait for 5 seconds

            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("VictoryZone: nextSceneName is not set.");
            }
        }
    }
}

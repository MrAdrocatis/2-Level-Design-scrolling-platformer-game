using UnityEngine;
using UnityEngine.Tilemaps;
using Platformer.Gameplay;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Komponen untuk Tilemap yang menyebabkan kematian pemain jika menyentuh tile spike.
    /// </summary>
    [RequireComponent(typeof(TilemapCollider2D))]
    public class Spike : MonoBehaviour
    {
        private TilemapCollider2D tilemapCollider;

        void Awake()
        {
            // Ambil komponen TilemapCollider2D
            tilemapCollider = GetComponent<TilemapCollider2D>();
            if (!tilemapCollider.isTrigger)
            {
                tilemapCollider.isTrigger = true; // Pastikan collider Tilemap diatur sebagai trigger
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            // Memeriksa apakah yang menyentuh tilemap adalah pemain
            var player = collider.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                // Menjadwalkan event PlayerDeath untuk mematikan pemain
                Simulation.Schedule<PlayerDeath>();
            }
        }
    }
}

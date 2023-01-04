using System;
using Industrio.Engine;

namespace Industrio.Entities;

public class CrawlerSpawnerEntity : Entity
{
    public float Delay { get; set; } = 5000f;

    private float _spawnTimer = 0;

    public CrawlerSpawnerEntity()
    {
        Name = $"CrawlerSpawner";

        OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        _spawnTimer += e.GameTime.ElapsedGameTime.Milliseconds;

        if (_spawnTimer >= Delay)
        {
            _spawnTimer = 0;

            var crawler = new CrawlerEntity()
            {
                Position = Position
            };

            IndustrioGame.Instance.Scene.SpawnQueue.Add(crawler);
        }
    }
}
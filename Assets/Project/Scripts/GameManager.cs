using UnityEngine;
/// <summary>
/// Менеджер игры.
/// </summary>
public class GameManager : MonoBehaviour
{
    int scoreMissed =0, scoreDone=0;
    [SerializeField] CatController catController; 
    [SerializeField] ViewController viewController;
    [SerializeField] SpawnController spawnController;
    [SerializeField] SoundSettings soundSettings;
    [SerializeField] MissedCounter missedCounter;
    [SerializeField] int miss;

    private void Start()
    {
        catController.onEdible += AddScoreDone;
        missedCounter.onMissed += AddScoreMissed;
        catController.onBomb += MinusScoreDone;
    }

    private void AddScoreMissed()
    {
        scoreMissed++;
        viewController.ChangeMissedPoint(scoreMissed);
        soundSettings.Meow();
        soundSettings.Mute();
        if (scoreMissed >= miss) GameOver();
    }

    private void AddScoreDone()
    {
        scoreDone++;
        viewController.ChangePoint(scoreDone);
        soundSettings.SoundAddition();
    }

    private void MinusScoreDone()
    {
        scoreDone-=2;
        viewController.ChangePoint(scoreDone);
        soundSettings.Meow();
        soundSettings.Mute();
        if (scoreDone < 0) GameOver();
    }

    private void GameOver()
    {
        spawnController.GameOver();
        viewController.GameOver();
        scoreDone = 0;
        scoreMissed = 0;
    }
}

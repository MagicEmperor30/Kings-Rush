using UnityEngine;

public class Coin : Pickup
{
   [SerializeField] int scoreAmount = 20;
    public ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager){
      this.scoreManager = scoreManager;
    }
    protected override void OnPickup()
    {
      scoreManager.IncreaseScore(scoreAmount);
    }
}

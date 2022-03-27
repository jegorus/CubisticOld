using UnityEngine;

public class GettingYellowCoin : MonoBehaviour
{
    public Movement player;
    public ParticleSystem CoinParticles;
    public SpriteRenderer coinModel;

    bool shouldDestroy = false;

    private void OnTriggerEnter2D()
    {
        if (!shouldDestroy)
        {
            FindObjectOfType<AudioManagerScript>().Play("PickUpCoin");
            ParticleSystem CoinEffect = Instantiate(CoinParticles, transform);
            player.IncreaseJumpsYellow();
            shouldDestroy = true;
            coinModel.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}

using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.CompleteLevel();
    }
}

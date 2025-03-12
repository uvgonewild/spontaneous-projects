using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject candyPrefab;
    [SerializeField] private VirtualCamFollow virtualCam;

    [SerializeField] private TMP_Text candiesCountDisplayText;

    public int maxCandies = 300;
    public bool canShoot = true;
    public int CandiesCount { get; private set; }

    private void Start()
    {
        CandiesCount = 30;
    }

    private void Update()
    {
        candiesCountDisplayText.text = $"{CandiesCount}";

        if (!virtualCam.isHeadEntityTweeking && canShoot)
        {
            if (Input.GetMouseButtonDown(0)
                && !virtualCam.isShopping && CandiesCount > 0)
            {
                ThrowCandy();
                CandiesCount--;
            }
        }
    }

    public void AddCandies(int candies)
    {
        if (candies + CandiesCount <= maxCandies) CandiesCount += candies;
        else CandiesCount = maxCandies;
    }

    void ThrowCandy()
    {
        Instantiate(candyPrefab, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
    }
}

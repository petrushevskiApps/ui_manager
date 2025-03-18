using System.Collections.Generic;
using UnityEngine;

public class UIStars : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _stars;

    private void Awake()
    {
        foreach (var star in _stars)
        {
            star.SetActive(false);
        }
    }

    public void SetData(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].SetActive(true);
        }
    }
}

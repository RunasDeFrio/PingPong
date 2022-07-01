using UnityEngine;

[CreateAssetMenu(fileName = "ProjectSettings", menuName = "ProjectSettings", order = 0)]
public class ProjectSettings : ScriptableObject
{
    [SerializeField] private GameObject racketPrefab;
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private GameObject timeTimeLevelPrefab;

    public GameObject RacketPrefab => racketPrefab;

    public GameObject BallPrefab => ballPrefab;

    public GameObject TimeLevelPrefab => timeTimeLevelPrefab;
}
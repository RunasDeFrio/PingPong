using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Все префабы и настройки находятся в этом классе.
    /// </summary>
    [CreateAssetMenu(fileName = "ProjectSettings", menuName = "ProjectSettings", order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        [SerializeField] private GameObject racketPrefab;
        [SerializeField] private GameObject ballPrefab;

        [SerializeField] private GameObject timeTimeLevelPrefab;
        [SerializeField] private BallInfo _ballInfo;

        public GameObject RacketPrefab => racketPrefab;

        public GameObject BallPrefab => ballPrefab;

        public GameObject TimeLevelPrefab => timeTimeLevelPrefab;

        public BallInfo BallInfo => _ballInfo;
    }
}
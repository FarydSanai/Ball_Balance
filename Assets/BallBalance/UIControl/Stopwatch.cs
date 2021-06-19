using UnityEngine;
using TMPro;
using TimeSpan = System.TimeSpan;


namespace BallBalance
{
    public class Stopwatch : MonoBehaviour
    {
        private bool timerIsActive = false;
        private float CurrentTime;
        [SerializeField]
        private TMP_FontAsset FontAsset;
        [SerializeField]
        private TextMeshProUGUI CurrentTimeText;
        private void Start()
        {
            CurrentTime = 0f;
        }
        private void Update()
        {
            if (timerIsActive)
            {
                CurrentTime += Time.deltaTime;
            }
            TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
            CurrentTimeText.text = time.ToString(@"mm\:ss\:fff");
            CurrentTimeText.font = FontAsset;
        }
        public void StopTimer()
        {
            timerIsActive = false;
        }
        public void StartTimer()
        {
            timerIsActive = true;
        }
    }
}

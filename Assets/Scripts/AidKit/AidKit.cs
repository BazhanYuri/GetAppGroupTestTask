using UnityEngine;




namespace TestTask
{
    public class AidKit : MonoBehaviour
    {
        [SerializeField] private AidKitConfig _aidKitConfig;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamagablePart damagablePart))
            {
                if (damagablePart.PlayerType != PlayerType.Player)
                {
                    return;
                }
                if (damagablePart.Damagable.IsMaxHealth == true)
                {
                    return;
                }
                damagablePart.Damagable.AddHealth(_aidKitConfig.HealingCount.GetRandom());
                gameObject.SetActive(false);
            }
        }
    }
}


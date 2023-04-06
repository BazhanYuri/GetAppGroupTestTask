using UnityEngine;
using DG.Tweening;



namespace TestTask
{
    public enum BulletType
    {
        Rifle,
        Cannon
    }
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Transform[] _views;

        private int _damage;
        private Sequence seq;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamagablePart damagablePart))
            {
                if (damagablePart.PlayerType != PlayerType.Player)
                { 
                damagablePart.Damagable.TakeHealth(_damage);

                }
            }
            HideBullet();
        }


       
        public void Shoot(Transform shooter, int damage, BulletType bulletType)
        {
            ChooseVisual(bulletType);
            _damage = damage;
            seq = DOTween.Sequence();
            seq.Append(transform.DOMove(shooter.forward * 60, 5));
            seq.AppendCallback(HideBullet);
        }

        private void HideBullet()
        {
            seq.Kill();
            gameObject.SetActive(false);
        }
        private void ChooseVisual(BulletType bulletType)
        {
            foreach (var item in _views)
            {
                item.gameObject.SetActive(false);
            }

            switch (bulletType)
            {
                case BulletType.Rifle:
                    _views[0].gameObject.SetActive(true);
                    break;
                case BulletType.Cannon:
                    _views[1].gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}


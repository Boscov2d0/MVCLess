using Game.Enemy;
using UnityEngine;

namespace Game.Player
{
    internal class PlayerModel
    {
        private readonly Camera _camera;
        private Ray _ray;
        private RaycastHit _hit;
        private int _power;

        public PlayerModel(PlayerProfile playerProfile, Camera camera) 
        {
            _camera = camera;
            _power = playerProfile.Power;

            Init();
        }
        private void Init() 
        {
            UpdateManager.Instance.SunscribeToUpdate(Execute);
        }
        private void Deinit() 
        {
            UpdateManager.Instance.UnSunscribeToUpdate(Execute);
        }
        public void Execute()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (_hit.collider.TryGetComponent(out EnemyView enemy))
                    {
                        TapOnMonster(enemy);
                    }
                }
            }
        }
        private void TapOnMonster(EnemyView enemy)
        {
            enemy.OnClick(_power);
        }
    }
}
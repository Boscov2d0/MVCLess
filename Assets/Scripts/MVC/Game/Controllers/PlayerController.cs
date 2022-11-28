using UnityEngine;

namespace Game.Player
{
    internal class PlayerController : DisposableObject
    {
        private readonly string _resourcePlayerProfilePath = "Settings/PlayerProfile";
        private readonly string _resourceCameraPath = "Main Camera";
        private readonly string _resourcePlayerViewPath = "Player";

        private readonly Camera _camera;
        private readonly PlayerProfile _playerProfile;
        private readonly PlayerView _playerView;
        private readonly PlayerModel _playerModel;
        public PlayerController() 
        {
            _playerProfile = LoadPlayerProfile();
            _camera = CreateCamera();
            _playerView = CreatePlayerView();
            //_camera = CreateObject<Camera>(_resourceCameraPath);
            //_playerView = CreateObject<PlayerView>(_resourceCameraPlayerViewPath);
            AddGameObject(_playerView.gameObject);
            _playerModel = new PlayerModel(_playerProfile, _camera); 
        }
        private PlayerProfile LoadPlayerProfile() 
        {
            return Resources.Load<PlayerProfile>(_resourcePlayerProfilePath);
        }
        private Camera CreateCamera() 
        {
            Camera cameraPrefab = Resources.Load<Camera>(_resourceCameraPath);
            return GameObject.Instantiate<Camera>(cameraPrefab);
        }
        private PlayerView CreatePlayerView() 
        {
            PlayerView playerViewPrefab = Resources.Load<PlayerView>(_resourcePlayerViewPath);
            return GameObject.Instantiate<PlayerView>(playerViewPrefab);
        }
        private T CreateObject<T>(string path)
        {
            GameObject playerViewPrefab = Resources.Load<GameObject>(path);
            return GameObject.Instantiate<GameObject>(playerViewPrefab).GetComponent<T>();
        }
    }
}
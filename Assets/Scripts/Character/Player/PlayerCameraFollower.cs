using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerCameraFollower : MonoBehaviour
    {
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField][Range(0, 1)] private float followStrenght;

        private void LateUpdate()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _playerCamera.transform.localPosition, followStrenght);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _playerCamera.transform.localRotation, followStrenght);
        }
    }
}
// using UnityEngine;

//     //주어진 Axe 오브젝트를 휘두루기
//     //알맞은 애니메이션을 재생하고 IK를 사용해 플레이어의 양손이 도끼에 위치하도록 하기
//     // Start is called before the first frame update
// public class PlayerAxeHold : MonoBehaviour
// {
//     public Axe axe;
//     public Transform axePivot;
//     public Transform leftHandMount;
//     public Transform rightHandMount;

//     private PlayerInput playerInput;
//     private Animator playerAnimator;

//     private void Start()
//     {
//         playerInput = GetComponent<PlayerInput>();
//         playerAnimator = GetComponent<Animator>();
//     }

//     private void OnEnable()
//     {
//         axe.gameObject.SetActive(true);
//     }

//     private void OnDisable()
//     {
//         axe.gameObject.SetActive(true);
//     }
    
//     private void Update()
//     {
//         //check input // swing axe?
//         if (playerInput.swing)
//         {
//             axe.Swing();
//             playerAnimator.SetTrigger("swing");
//         }
//     }

//     private void OnAnimatorIK(int layerIndex) 
//     {
//         //axePivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightHand);

//         playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
//         playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

//         playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandMount.position);
//         playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandMount.rotation);

//         playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
//         playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

//         playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandMount.position);
//         playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandMount.rotation);

//     }
    
// }

// using UnityEngine;

//     //주어진 Axe 오브젝트를 휘두루기
//     //알맞은 애니메이션을 재생하고 IK를 사용해 플레이어의 양손이 도끼에 위치하도록 하기
// public class PlayerAxeHold : MonoBehaviour
// {
//     public Axe axe; //사용할 도끼(Axe 게임 오브젝트의 Axe 컴퍼넌트)

//     //IK에 사용할 변수들 
//     public Transform axePivot; //도끼 배치의 기준점
//     public Transform leftHandMount; //도끼의 왼쪽 손잡이, 왼손이 위치할 지점
//     public Transform rightHandMount; //도끼의 오른쪽 손잡이, 오른손이 위치할 지점

//     private PlayerInput playerInput; //플레이어의 입력
//     private Animator playerAnimator; //애니메이터 컴퍼넌트

//     private void Start()
//     {//사용할 컴퍼넌트 가져오기
//         playerInput = GetComponent<PlayerInput>();
//         playerAnimator = GetComponent<Animator>();
//     }

//     private void OnEnable()
//     {//axehold가 활성화될 때 도끼도 함께 활성화
//         axe.gameObject.SetActive(true);
//     }

//     private void OnDisable()
//     {//axehold가 비활성화될 때 도끼도 함께 비활성화
//         axe.gameObject.SetActive(false);
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

//     //애니메이터의 IK 갱신
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

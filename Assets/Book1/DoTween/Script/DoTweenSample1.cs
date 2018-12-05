using UnityEngine;
using UnityEngine.UI;

//DoTweenを利用するために必要なusing文
using DG.Tweening;

//DoTweenのサンプルクラス
public class DoTweenSample1 : MonoBehaviour
{
    //ジャンプしたり、振動したりするキャラクター
    [SerializeField] GameObject character;

    //ジャンプアップ、ジャンプアップ落下、振動の３種類のボタン
    [SerializeField] Button jumpUpButton;
    [SerializeField] Button jumpUpAndDownButton;
    [SerializeField] Button shakeButton;

    //初期位置
    Vector3 initialPosition;

    //シーンの最初に一度だけ呼ばれる
    //初期化やイベントの登録に使う
    void Start()
    {
        //初期位置を記憶する
        initialPosition = character.transform.position;

        //ボタンに対するイベントの追加
        //ボタンに、キャラがジャンプアップするようにイベントを登録
        jumpUpButton.onClick.AddListener(JumpUp);

        //ボタンに、キャラがジャンプアップしてから落下するようにイベントを登録
        jumpUpAndDownButton.onClick.AddListener(JumpUpAndDown);

        //ボタンに、キャラが振動するようにイベントを登録
        shakeButton.onClick.AddListener(Shake);
    }

    //キャラをジャンプアップさせる
    void JumpUp()
    {
        //もし、DoTweenが実行中の場合、停止させる
        character.transform
             .DOKill(true);//trueを代入することで、完了(OnComplete)時のイベントが走る

        //Tweenを開始する前に、初期位置に移動
        character.transform.position = initialPosition;

        //Tweenの設定
        character.transform
             .DOMoveY(1.5f, 0.5f)//Y方向に、1.5fの距離、0.5f秒移動
             .SetRelative(true)//相対的な位置で移動
             .OnComplete(() => character.transform.position = initialPosition);
            //完了時に初期位置に戻る
    }

    //キャラをジャンプアップさせてから、往復運動により落下させる
    void JumpUpAndDown()
    {
        character.transform
             .DOKill(true);

        character.transform.position = initialPosition;

        //繰り返し２回（登り１回、下り１回）、LoopType.Yoyoにより往復の運動になる。
        character.transform
             .DOMoveY(1.5f, 0.5f)
             .SetRelative(true)
             .SetLoops(2, LoopType.Yoyo)
             .OnComplete(() => character.transform.position = initialPosition);
    }

    //キャラを振動させる
    void Shake()
    {
        character.transform
             .DOKill(true);

        character.transform.position = initialPosition;

        //0.5f秒、0.5fの振れ幅で、振動ビブラートが30の振動
        character.transform
             .DOShakePosition(0.5f, 0.5f, 30)
             .OnComplete(() => character.transform.position = initialPosition);
    }
}

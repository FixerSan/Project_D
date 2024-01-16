public class Define
{
    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    public enum PlayerState
    {
        Idle, Follow, Move, Attack, SkillCast, Die
    }

    public enum Enemy
    {

    }

    public enum MonsterState
    {
        Create, Idle, Move, Follow, Attack, SkillCast, Die
    }

    public enum MemberState
    {
        Idle, Move, Attack, SkillCast, Die
    }


    public enum VoidEventType
    {

    }

    public enum IntEventType
    {

    }

    public enum UIEventType
    {
        Click,
        Pressed,
        PointerDown,
        PointerUp,
        BeginDrag,
        Drag,
        EndDrag,
        Drop
    }

    public enum UIType
    {

    }

    public enum Scene
    {
        Login, Main, Stage, Test
    }

    public enum SoundType
    {

    }
}

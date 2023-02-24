namespace Yangen
{
    public interface IMutationSchema
    {
        IMutationSchema AddAction(IMutationAction action);
        IMutationSchema AddCondition(IMutationCondition condition);
        bool IsValidName(Name name);
        void ApplyForName(Name name);
    }
}
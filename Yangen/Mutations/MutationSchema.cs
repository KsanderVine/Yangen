namespace Yangen
{
    public sealed class MutationSchema : IMutationSchema
    {
        private readonly List<IMutationAction> _actions;
        private readonly List<IMutationCondition> _conditions;

        public MutationSchema()
        {
            _actions = new List<IMutationAction>();
            _conditions = new List<IMutationCondition>();
        }

        public IMutationSchema AddAction(IMutationAction action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            _actions.Add(action);
            return this;
        }

        public IMutationSchema AddCondition(IMutationCondition condition)
        {
            if (condition is null)
                throw new ArgumentNullException(nameof(condition));

            _conditions.Add(condition);
            return this;
        }

        public bool IsValidName(Name name)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            foreach (var condition in _conditions)
            {
                if (!condition.IsValidName(name))
                {
                    return false;
                }
            }

            return true;
        }

        public void ApplyForName(Name name)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            foreach (var action in _actions)
            {
                action.ApplyForName(name);
            }
        }
    }
}
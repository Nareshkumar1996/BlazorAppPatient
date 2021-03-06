

namespace Healthware.Assist.Core.Utility
{
    public class ChainedMapper<Left, Middle, Right> : IMapper<Left, Right>
    {
        private readonly IMapper<Left, Middle> left;
        private readonly IMapper<Middle, Right> right;

        public ChainedMapper(IMapper<Left, Middle> left, IMapper<Middle, Right> right)
        {
            this.left = left;
            this.right = right;
        }

        public Right MapFrom(Left item)
        {
            return right.MapFrom(left.MapFrom(item));
        }
    }
}
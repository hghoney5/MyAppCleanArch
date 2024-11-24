using App.Core.Entities;
using App.Core.Interfaces;
using MediatR;

namespace App.Application.Queries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<User>>;

    public class GetAllUsersQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUsersAsync();
        }
    }
}

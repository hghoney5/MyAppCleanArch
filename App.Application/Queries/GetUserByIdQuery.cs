using App.Core.Entities;
using App.Core.Interfaces;
using MediatR;

namespace App.Application.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<User>;

    public class GetUserByIdQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetUserByIdQuery, User>
    {
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByIdAsync(request.Id);
        }
    }
}

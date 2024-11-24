using App.Core.Entities;
using App.Core.Interfaces;
using MediatR;

namespace App.Application.Commands
{
    public record UpdateUserCommand(int Id, User User) : IRequest<User>;

    public class UpdateUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<UpdateUserCommand, User>
    {
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.UpdateUserAsync(request.Id, request.User);
        }
    }
}

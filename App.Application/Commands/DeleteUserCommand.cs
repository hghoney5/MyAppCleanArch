using App.Core.Interfaces;
using MediatR;

namespace App.Application.Commands
{
    public record DeleteUserCommand(int Id) : IRequest<bool>;

    public class DeleteUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.DeleteUserAsync(request.Id);
        }
    }
}

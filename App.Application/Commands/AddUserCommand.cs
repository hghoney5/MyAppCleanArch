using App.Core.Entities;
using App.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Commands
{
    public record AddUserCommand(User User): IRequest<User>;

    public class AddUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<AddUserCommand, User>
    {
        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.AddUserAsync(request.User);
        }
    }
}

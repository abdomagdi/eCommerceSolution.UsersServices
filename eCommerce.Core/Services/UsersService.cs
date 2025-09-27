using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    public class UsersService(IUsersRepository _usersRepository,IMapper _mapper) : IUsersService
    {
       
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
          ApplicationUser? user = await  _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "Token" }; ;
            //return new AuthenticationResponse(
            //    user.UserId, user.Email, user.Password, user.PersonName, user.Gender,
            //    "Token", true
            //    );
        }

        public async Task<AuthenticationResponse?> Registation(RegisterationRequest registerationRequest)
        {
            //ApplicationUser user = new ApplicationUser()
            //{
               
            //    Password = registerationRequest.Password,
            //    PersonName = registerationRequest.PersonName,
            //    Email = registerationRequest.Email,
            //    Gender = registerationRequest.Gender.ToString()
            //};

            ApplicationUser user = _mapper.Map<ApplicationUser>(registerationRequest);
            ApplicationUser? registerdUser = await _usersRepository.AddUser(user);
            if (registerdUser == null)
            {
                return null;
            }
            return _mapper.Map<AuthenticationResponse>(user) with { Success=true, Token="Token"};

            //return new AuthenticationResponse(
            //   registerdUser.UserId, registerdUser.Email, registerdUser.Password, registerdUser.PersonName, registerdUser.Gender,
            //   "Token", true
            //   );
        }
    }
}

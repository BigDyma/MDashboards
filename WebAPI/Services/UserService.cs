using AutoMapper;
using Common.Exceptions;
using Entity;
using Entity.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;
using WebAPI.Model.Dto.Reports;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; }
        private IProjectRepository _projectRepository { get; }

        private UserManager<User> _userManager { get; }
        private IMapper _mapper { get; }
        public UserService(UserManager<User> userManager, IUserRepository userRepository, IMapper mapper, IProjectRepository projectRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
            _userManager = userManager;
        }
        public async Task DeleteUser(long id)
        {
           var res = await _userRepository.GetEntity(id);

            checkExistance(res);

            await _userRepository.DeleteUser(id);
        }

        public async Task<UserResponseDto> GetUser(long id)
        {
            var user = await _userRepository.GetEntity(id);

            checkExistance(user);

            var output = _mapper.Map<UserResponseDto>(user);

            return output;
        }

        public async Task<ICollection<ProjectResponseDto>> GetUserProjects(long id)
        {
           var res =  await _userRepository.GetProjects(id);

            var output = _mapper.Map<ICollection<ProjectResponseDto>>(res);

            return output;
        }

        public async Task<ICollection<ReportResponseDto>> GetUserReports(long id)
        {
            var allUserReports = await _projectRepository.GetAllUserReports(id);

            var output = _mapper.Map<ICollection<ReportResponseDto>>(allUserReports);

            return output;
        }

        public async Task<UserResponseDto> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var res = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());

            checkExistance(res);

            res.UserName = userUpdateDto.UserName;

            await _userRepository.Update(res);

            return null;
        }
        private void checkExistance(User user)
        {
            if (user == null)
                throw new EntityNotFoundException("", "No such user exist");
        }
    }
}

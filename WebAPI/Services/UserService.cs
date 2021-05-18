﻿using AutoMapper;
using Common.Exceptions;
using Entity;
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
        private IMapper _mapper { get; }
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
            var res = await _userRepository.GetReports(id);

            var output = _mapper.Map<ICollection<ReportResponseDto>>(res);

            return output;
        }

        public async Task<UserResponseDto> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);

            checkExistance(user);

            await _userRepository.Update(user);

            var output = _mapper.Map<UserResponseDto>(user);

            return output;
        }
        private void checkExistance(User user)
        {
            if (user == null)
                throw new EntityNotFoundException("", "No such user exist");
        }
    }
}

﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeDetails
{
    public class GetLeaveTypeDetaislQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery,LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetaislQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the dateabase
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id) ?? 
                throw new NotFoundException(nameof(LeaveType),request.Id);
        
            // convert data object to DTO objects
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);
            // return list of DTO object
            return data;
        }
    }
}

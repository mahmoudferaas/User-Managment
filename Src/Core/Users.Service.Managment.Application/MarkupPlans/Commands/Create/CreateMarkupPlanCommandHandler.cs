using AutoMapper;
using BaseClasses.Core.Utilities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.MarkupPlans.Commands.Create
{
    public class CreateMarkupPlanCommandHandler : IRequestHandler<CreateMarkupPlanCommand, int>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public CreateMarkupPlanCommandHandler(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMarkupPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MarkupPlan>(request);
            _context.MarkupPlans.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
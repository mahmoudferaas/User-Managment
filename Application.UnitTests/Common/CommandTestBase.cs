using AutoMapper;
using Moq;
using System;
using Users.Service.Managment.Persistence;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly UserDBContext _context;
        protected readonly Mock<IMapper> _mapperMock;

        public CommandTestBase()
        {
            _context = ContextFactory.Create();
            _mapperMock = new Mock<IMapper>();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }
    }
}
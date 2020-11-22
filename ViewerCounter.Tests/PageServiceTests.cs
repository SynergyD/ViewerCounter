using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ViewerCounter.DAL.Entities;
using ViewerCounter.DAL.Interfaces;
using ViewerCounter.Services;
using Xunit;

namespace ViewerCounter.Tests
{
    public class PageServiceTests
    {
        private readonly PageService _pageService;
        private readonly Mock<IDbRepository> mockRepository;
        
        public PageServiceTests()
        {
            mockRepository = new Mock<IDbRepository>();

            mockRepository.Setup(m => m.GetAll<View>()).Returns(new List<View>()
            {
                new View(),
                new View()
            }.AsQueryable());

            _pageService = new PageService(mockRepository.Object);
        }

        [Fact]
        public void RegisterView_ShouldWork()
        {
            var view = new View()
            {
                UserId = "UserId"
            };
            
            _pageService.RegisterView(view);
            
            mockRepository.Verify(m=>m.Add(view), Times.Once);
            mockRepository.Verify(m=>m.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task RegisterView_ViewIsNull_ArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _pageService.RegisterView(null));
        }
        
        [Fact]
        public async Task RegisterView_UserIdIsEmpty_ArgumentException()
        {
            var action = new Func<Task>(async () => await _pageService.RegisterView(new View()));
            var exception = Assert.ThrowsAsync<ArgumentException>(action);
            
            Assert.Equal("Incorrect View", exception.Result.Message);
        }

        [Fact]
        public void GetInfo_ShouldWork()
        {
            var actualList = _pageService.GetInfo();

            var expected = 2;
            
            Assert.Equal(expected, actualList.Count);
        }

        [Fact]
        public void GetInfo_ThrowException()
        {
            mockRepository.Setup(m => m.GetAll<View>()).Throws<Exception>();

            Assert.Throws<Exception>(() =>  _pageService.GetInfo());
        }
    }
}
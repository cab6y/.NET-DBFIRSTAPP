using Application.TodoItems;
using Application.TodoItems.Dtos;
using AutoMapper;
using Domain.Entities.TodoItem;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject
{
    public class TodoItemAppServiceTests
    {
        private readonly Mock<ITodoItemRepository> _todoItemRepositoryMock;
        private readonly IMapper _mapper;
        private readonly TodoItemAppService _service;

        public TodoItemAppServiceTests()
        {
            _todoItemRepositoryMock = new Mock<ITodoItemRepository>();

            // Doðru AutoMapper konfigürasyonu
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TodoItemMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _service = new TodoItemAppService(_todoItemRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnTrue_WhenRepositoryReturnsTrue()
        {
            var dto = new CreateTodoItemDto { Title = "Test", Description = "Desc", IsCompleted = false };
            _todoItemRepositoryMock.Setup(r => r.AddAsync(It.IsAny<TodoItem>())).ReturnsAsync(true);

            var result = await _service.AddAsync(dto);

            Assert.True(result);
            _todoItemRepositoryMock.Verify(r => r.AddAsync(It.IsAny<TodoItem>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldReturnTrue_WhenRepositoryReturnsTrue()
        {
            int id = 1;
            _todoItemRepositoryMock.Setup(r => r.Delete(id)).ReturnsAsync(true);

            var result = await _service.Delete(id);

            Assert.True(result);
            _todoItemRepositoryMock.Verify(r => r.Delete(id), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnMappedDto_WhenEntityExists()
        {
            var entity = new TodoItem { Id = 1, Title = "Test", Description = "Desc", IsCompleted = false };
            _todoItemRepositoryMock.Setup(r => r.GetAsync(1)).ReturnsAsync(entity);

            var result = await _service.GetAsync(1);

            Assert.NotNull(result);
            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.Title, result.Title);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedDtoList()
        {
            var entities = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Test1", Description = "Desc1", IsCompleted = false },
                new TodoItem { Id = 2, Title = "Test2", Description = "Desc2", IsCompleted = true }
            };
            _todoItemRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Test1", result[0].Title);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrue_WhenRepositoryReturnsTrue()
        {
            var dto = new TodoItemDto { Id = 1, Title = "Updated", Description = "Desc", IsCompleted = true };
            _todoItemRepositoryMock.Setup(r => r.UpdateAsync(It.IsAny<TodoItem>())).ReturnsAsync(true);

            var result = await _service.UpdateAsync(dto);

            Assert.True(result);
            _todoItemRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TodoItem>()), Times.Once);
        }
    }
}

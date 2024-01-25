using static HHD.Service.Services.Categories.CategoryService;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using HHD.Service.Interfaces.Categories;
using HHD.DAL.IRepositories.Categories;
using HHD.Service.DTOs.Categories;
using HHD.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
namespace HHD.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IQueryable<Category> Get(
        Expression<Func<Category, bool>>? predicate = default,
        bool asNoTracking = false) =>
    _categoryRepository.SelectAll(predicate, asNoTracking);

    public async ValueTask<IEnumerable<CategoryForResultDto>> GetAsync(bool asNoTracking = false)
    {
        var todos = await Get().ToListAsync();

        return todos
      
    }

    public ValueTask<ToDoItem?> GetByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default) =>
    toDoRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public ValueTask<IList<ToDoItem>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default) =>
    toDoRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<ToDoItem> CreateAsync(
        ToDoItem toDoItem,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(toDoItem);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        toDoItem.CreatedTime = DateTimeOffset.UtcNow;

        return toDoRepository.CreateAsync(toDoItem, saveChanges, cancellationToken);
    }

    public ValueTask<ToDoItem> UpdateAsync(
        ToDoItem toDoItem,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(toDoItem);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return toDoRepository.UpdateAsync(toDoItem, saveChanges, cancellationToken);
    }

    public ValueTask<ToDoItem?> DeleteAsync(
        ToDoItem toDoItem,
        bool saveChanges = true,
        CancellationToken cancellationToken = default) =>
    toDoRepository.DeleteAsync(toDoItem, saveChanges, cancellationToken);

    public ValueTask<ToDoItem?> DeleteByIdAsync(
        Guid id,
        bool saveChanges = true,
        CancellationToken cancellationToken = default) =>
    toDoRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

}

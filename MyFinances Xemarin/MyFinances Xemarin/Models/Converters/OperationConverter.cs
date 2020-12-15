using MyFinances.Core.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace MyFinances Xemarin.Models.Converters
{
    public class OperationConverter
{
    public static OperationDto ToDto(this Operations model)
    {
        return new OperationDto
        {
            Id = model.Id,
            CategoryId = model.CategoryId,
            Date = model.Date,
            Description = model.Description,
            Name = model.Name,
            Value = model.Value
        };
    }

    public static IEnumerable<OperationDto> ToDtos(
        this IEnumerable<Operations> model)
    {
        if (model == null)
            return Enumerable.Empty<OperationDto>();

        return model.Select(x => x.ToDto());

    }

    public static Operations ToDao(this OperationDto model)
    {
        return new Operations
        {
            Id = model.Id,
            CategoryId = model.CategoryId,
            Date = model.Date,
            Description = model.Description,
            Name = model.Name,
            Value = model.Value
        };
    }
}
}
}

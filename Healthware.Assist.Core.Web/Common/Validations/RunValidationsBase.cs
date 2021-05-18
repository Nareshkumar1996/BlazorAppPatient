using System.Collections.Generic;
using System.Linq;
using Healthware.Assist.Core.Dtos;

namespace Healthware.Assist.Core.Web.Common.Validations
{
    public abstract class RunValidationsBase<T>
    {
        public IEnumerable<IValidator<T>> Validators { get; set; } = new List<IValidator<T>>();

        public IEnumerable<ValidationErrorDto<T>> Validate(IEnumerable<T> items)
        {
            var validatorErrors = new List<ValidationErrorDto<T>>();
            var itemList = items.ToList();
            foreach (var item in itemList)
            {
                var validationErrors = Validators.Select(x => x.Execute(item, itemList)).Where(x => x.IsValid == false).Select(x=>x.Message);
                
                if (validationErrors.Any())
                {
                    validatorErrors.Add(new ValidationErrorDto<T>
                    {
                        ErrorMessages = validationErrors,
                        item = item
                    });
                }
            }

            return validatorErrors;
        }

        public ValidationErrorDto<T> Validate(T item)
        {
            
            var validationErrors = Validators.Select(x => x.Execute(item)).Where(x => x.IsValid == false).Select(x=>x.Message);
            if (!validationErrors.Any()) return null;

            return new ValidationErrorDto<T>
            {
                ErrorMessages = validationErrors,
                item = item
            };
        }
    }
}
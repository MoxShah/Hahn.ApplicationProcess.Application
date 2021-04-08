namespace Hahn.ApplicationProcess.February2021.Domain.Validators
{
    using System;
    using FluentValidation;
    using Hahn.ApplicationProcess.February2021.Data.Interfaces;
    using Hahn.ApplicationProcess.February2021.Domain.BusinessModels;
    using Hahn.ApplicationProcess.February2021.Domain.Common;

    /// <summary>
    /// Asset Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{BusinessModels.AssetModel}" />
    public class AssetValidator : AbstractValidator<AssetModel>
    {
        int ASSET_NAME_LENGHT = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetValidator"/> class.
        /// </summary>
        public AssetValidator(ICountryValidator countryValidator)
        {
            RuleFor(x => x.AssetName).NotNull().WithMessage(Constants.ASSET_NAME_REQUIRED).MinimumLength(ASSET_NAME_LENGHT).WithMessage(string.Format(Constants.ASSET_NAME_LENGTH, ASSET_NAME_LENGHT));
            RuleFor(x => x.Department).NotNull().WithMessage(Constants.DEPARTMENT_REQUIRED).IsInEnum().WithMessage(Constants.DEPARTMENT_INVALID);
            RuleFor(x => x.PurchaseDate).NotNull().WithMessage(Constants.PURCHASE_DATE_REQUIRED).Must(curDate => curDate >= DateTime.Now.AddDays(-365)).WithMessage(Constants.PURCHASE_DATE_INVALID);
            RuleFor(x => x.EMailAddressOfDepartment).NotNull().WithMessage(Constants.EMAIL_REQUIRED).EmailAddress().WithMessage(Constants.EMAIL_INVALID);
            RuleFor(x => x.CountryOfDepartment).NotNull().WithMessage(Constants.COUNTRY_REQUIRED).Must(a =>
            {
                if (!string.IsNullOrEmpty(a))
                    return countryValidator.ValidateCountryByName(a);
                else
                    return true;
            }).WithMessage(Constants.COUNTRY_INVALID);
        }
    }
}

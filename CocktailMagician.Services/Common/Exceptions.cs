using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.CommonMessages
{
    public static class Exceptions
    {
        public const string NullEntityId = "Given Id was not found";
        public const string NameExists = "This name already exists!";
        public const string MissingName = "The name is mandatory";

        public const string AlreadyListed = "{0} already contains {1}";

        public const string EntityNotFound = "The entity was not found!";
        public const string InvalidSearchCriteria = "Invalid search criteria";

        // Exceptions for controllers
        public const string SomethingWentWrong = "Ooops... something went wrong";
        public const string SuccessfullyCreated = "Successfully created";
        public const string SuccessfullyDeleted = "Successfully deleted";
        public const string SuccessfullyUpdated = "Successfully updated";




    }
}

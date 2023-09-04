global using Newtonsoft.Json;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;


namespace top_library_models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum TransactionType
    {
        Give,
        Receive,
        Return
    }
}
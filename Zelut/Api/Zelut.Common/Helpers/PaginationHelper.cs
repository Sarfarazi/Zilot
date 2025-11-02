using System.ComponentModel.DataAnnotations;

namespace Zelut.Common.Helpers;

public class PaginationParameters
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public string? SortOrder { get; set; }
    public string? Search { get; set; }
}

public sealed class PaginationHelper
{
    public static string GetSortWithPagingSqlCommand(PaginationParameters parameters, string obj)
    {
        if (string.IsNullOrEmpty(parameters.SortOrder))
        {
            return string.Empty;
        }

        var sort_sql_split = parameters.SortOrder.Split("_");
        string sql_sort_ascending_descending = sort_sql_split[1] == "A" ? "asc" : "desc";

        string str_sort_order = (sort_sql_split.Length > 0 ? $"ORDER BY {obj}.{sort_sql_split[0]} {sql_sort_ascending_descending}" : $"ORDER BY {obj}.Id DESC");

        string strRes = @$"{(parameters.PageIndex == 0 && parameters.PageSize == 0 ? str_sort_order : @$"
                            {str_sort_order}
                            OFFSET {(parameters.PageIndex == 1 ? 0 : (parameters.PageIndex - 1) * parameters.PageSize)} ROWS
                            FETCH NEXT {parameters.PageSize} ROWS ONLY")}";

        return strRes;
    }
}
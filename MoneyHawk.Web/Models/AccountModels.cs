using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MoneyHawk.Web.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Helpers;

    using NetIndustry.Library;

    using Enumerable = System.Linq.Enumerable;

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [Required]
        public string SubDomain { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string SubDomain { get; set; }
    }

    /// <summary>
    /// Wrapper for System.Web.Helpers.WebGrid that preserves the item type from the data source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WebGrid<T> : WebGrid
    {
        /// <param name="source">Data source</param>
        /// <param name="columnNames">Data source column names. Auto-populated by default.</param>
        /// <param name="defaultSort">Default sort column.</param>
        /// <param name="rowsPerPage">Number of rows per page.</param>
        /// <param name="canPage">true to enable paging</param>
        /// <param name="canSort">true to enable sorting</param>
        /// <param name="ajaxUpdateContainerId">ID for the grid's container element. This enables AJAX support.</param>
        /// <param name="ajaxUpdateCallback">Callback function for the AJAX functionality once the update is complete</param>
        /// <param name="fieldNamePrefix">Prefix for query string fields to support multiple grids.</param>
        /// <param name="pageFieldName">Query string field name for page number.</param>
        /// <param name="selectionFieldName">Query string field name for selected row number.</param>
        /// <param name="sortFieldName">Query string field name for sort column.</param>
        /// <param name="sortDirectionFieldName">Query string field name for sort direction.</param>
        public WebGrid(IEnumerable<T> source = null, IEnumerable<string> columnNames = null, string defaultSort = null, int rowsPerPage = 10, bool canPage = true, bool canSort = true, string ajaxUpdateContainerId = null, string ajaxUpdateCallback = null, string fieldNamePrefix = null, string pageFieldName = null, string selectionFieldName = null, string sortFieldName = null, string sortDirectionFieldName = null)
            : base(source.SafeCast<object>(), columnNames, defaultSort, rowsPerPage, canPage, canSort, ajaxUpdateContainerId, ajaxUpdateCallback, fieldNamePrefix, pageFieldName, selectionFieldName, sortFieldName, sortDirectionFieldName)
        {
        }

        public WebGridColumn Col(string columnName = null, string header = null, Func<T, object> format = null, string style = null, bool canSort = true)
        {
            Func<dynamic, object> wrappedFormat = null;
            if (format != null)
            {
                wrappedFormat = o => format((T)o.Value);
            }
            WebGridColumn column = Column(columnName, header, wrappedFormat, style, canSort);
            return column;
        }

        public WebGrid<T> Bind(IEnumerable<T> source, IEnumerable<string> columnNames = null, bool autoSortAndPage = true, int rowCount = -1)
        {
            Bind(source.SafeCast<object>(), columnNames, autoSortAndPage, rowCount);
            return this;
        }
    }

    public static class WebGridExtensions
    {
        /// <summary>
        /// Light-weight wrapper around the constructor for WebGrid so that we get take advantage of compiler type inference
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="source">Data source</param>
        /// <param name="columnNames">Data source column names. Auto-populated by default.</param>
        /// <param name="defaultSort">Default sort column.</param>
        /// <param name="rowsPerPage">Number of rows per page.</param>
        /// <param name="canPage">true to enable paging</param>
        /// <param name="canSort">true to enable sorting</param>
        /// <param name="ajaxUpdateContainerId">ID for the grid's container element. This enables AJAX support.</param>
        /// <param name="ajaxUpdateCallback">Callback function for the AJAX functionality once the update is complete</param>
        /// <param name="fieldNamePrefix">Prefix for query string fields to support multiple grids.</param>
        /// <param name="pageFieldName">Query string field name for page number.</param>
        /// <param name="selectionFieldName">Query string field name for selected row number.</param>
        /// <param name="sortFieldName">Query string field name for sort column.</param>
        /// <param name="sortDirectionFieldName">Query string field name for sort direction.</param>
        /// <returns></returns>
        public static WebGrid<T> Grid<T>(this HtmlHelper htmlHelper,
                                                 IEnumerable<T> source,
                                                 IEnumerable<string> columnNames = null,
                                                 string defaultSort = null,
                                                 int rowsPerPage = 10,
                                                 bool canPage = true,
                                                 bool canSort = true,
                                                 string ajaxUpdateContainerId = null,
                                                 string ajaxUpdateCallback = null,
                                                 string fieldNamePrefix = null,
                                                 string pageFieldName = null,
                                                 string selectionFieldName = null,
                                                 string sortFieldName = null,
                                                 string sortDirectionFieldName = null)
        {
            return new WebGrid<T>(source, columnNames,
                                      defaultSort,
                                      rowsPerPage,
                                      canPage,
                                      canSort,
                                      ajaxUpdateContainerId,
                                      ajaxUpdateCallback,
                                      fieldNamePrefix,
                                      pageFieldName,
                                      selectionFieldName,
                                      sortFieldName,
                                      sortDirectionFieldName);
        }

        /// <summary>
        /// Light-weight wrapper around the constructor for WebGrid so that we get take advantage of compiler type inference and to automatically call Bind to disable the automatic paging and sorting (use this for server-side paging)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="source"></param>
        /// <param name="totalRows"></param>
        /// <param name="columnNames"></param>
        /// <param name="defaultSort"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="canPage"></param>
        /// <param name="canSort"></param>
        /// <param name="ajaxUpdateContainerId"></param>
        /// <param name="ajaxUpdateCallback"></param>
        /// <param name="fieldNamePrefix"></param>
        /// <param name="pageFieldName"></param>
        /// <param name="selectionFieldName"></param>
        /// <param name="sortFieldName"></param>
        /// <param name="sortDirectionFieldName"></param>
        /// <returns></returns>
        public static WebGrid<T> ServerPagedGrid<T>(this HtmlHelper htmlHelper,
                                                    IEnumerable<T> source,
                                                    int totalRows,
                                                    IEnumerable<string> columnNames = null,
                                                    string defaultSort = null,
                                                    int rowsPerPage = 10,
                                                    bool canPage = true,
                                                    bool canSort = true,
                                                    string ajaxUpdateContainerId = null,
                                                    string ajaxUpdateCallback = null,
                                                    string fieldNamePrefix = null,
                                                    string pageFieldName = null,
                                                    string selectionFieldName = null,
                                                    string sortFieldName = null,
                                                    string sortDirectionFieldName = null)
        {
            var webGrid = new WebGrid<T>(null,
                columnNames,
                                             defaultSort,
                                             rowsPerPage,
                                             canPage,
                                             canSort,
                                             ajaxUpdateContainerId,
                                             ajaxUpdateCallback,
                                             fieldNamePrefix,
                                             pageFieldName,
                                             selectionFieldName,
                                             sortFieldName,
                                             sortDirectionFieldName);
            return webGrid.Bind(source, rowCount: totalRows, autoSortAndPage: false);
        }
    }

}

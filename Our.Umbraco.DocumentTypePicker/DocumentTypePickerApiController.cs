using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace RB.DocumentTypePicker.Controllers.Api
{
    /// <summary>
    /// Umbraco API Controller for the Document Type Picker data type.
    /// </summary>
    [PluginController("DocumentTypePicker")]
    public class DocumentTypePickerApiController : UmbracoAuthorizedJsonController
    {
        /// <summary>
        /// Get method to retrieve a list of all document types.
        /// </summary>
        /// <returns>A sorted list of all document types.</returns>
        public object GetAllDocumentTypes()
        {
            var retval = new List<Object>();

            foreach (var doctype in Services.ContentTypeService.GetAllContentTypes().OrderBy(d => d.Name))
                retval.Add(new { alias = doctype.Alias, name = doctype.Name });

            return retval;
        }
    }
}
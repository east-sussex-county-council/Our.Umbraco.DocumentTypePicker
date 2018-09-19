using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RB.DocumentTypePicker.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;

namespace RB.DocumentTypePicker.Converters
{
    /// <summary>
    /// Value converter class to convert a json document type picker value object
    /// to a list of document type aliases.
    /// </summary>
    [PropertyValueType(typeof(List<string>))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class DocumentTypePickerValueConverter : PropertyValueConverterBase
    {
        /// <summary>
        /// Method to convert a property value to alist of document 
        /// type aliases
        /// </summary>
        /// <param name="propertyType">The current published property
        /// type to convert.</param>
        /// <param name="source">The original property data.</param>
        /// <param name="preview">True if in preview mode.</param>
        /// <returns>A list of document type aliases.</returns>
        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
                return null;

            if (UmbracoContext.Current == null)
                return null;

            var retval = new List<string>();

            var doctypes = JsonConvert.DeserializeObject<DocumentTypePickerDocTypes>(source.ToString());
            if (doctypes == null || doctypes.Count < 0)
                return retval;

            retval.AddRange(doctypes.Select(doctype => doctype.Alias));

            return retval;
        }

        /// <summary>
        /// Method to see if the current property type is of type
        /// document type picker.
        /// </summary>
        /// <param name="propertyType">The current property type.</param>
        /// <returns>True if the current property type of of type
        /// document type picker.</returns>
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("RB.DocumentTypePicker");
        }
    }
}
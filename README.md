# RB: Document Type Picker

The Document Type Picker package allows editors to choose a list of Document Types to be saved against a content page. This could be used for things like site map exclusions or navigation lists.

## Set Up

Create a new data type using the RB.DocumentTypePicker property editor. Add a new property to a document type using the new data type you have just created. Once you have created your new property, you should be able to choose from a list of current document types present within your Umbraco solution.

## Converter

When using a property value on a template, add the following code to return and use a list of document type aliases.

    @{
        IEnumerable<string> documentTypes = CurrentPage.GetPropertyValue<IEnumerable<string>>("alias");
    }
	
Once converted, you will be able to select or loop through each document type. For example:

    @{
        // Loop through each alias
        foreach (var documentType in documentTypes)
        {
            @documentType;
        }
    }

## Original version

This code is from a [repository on BitBucket](https://bitbucket.org/rbdigital/umbraco-documenttype-picker) by RB. The original version is published as an Umbraco package. This version publishes the same code as a NuGet package called `Our.Umbraco.DocumentTypePicker`.
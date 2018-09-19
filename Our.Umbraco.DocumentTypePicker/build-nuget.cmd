@echo off
set nuspec="%1"
set nuspec=%nuspec:\=\\%
nuget pack "%nuspec%Our.Umbraco.DocumentTypePicker.nuspec"
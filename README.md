# Bysykkel

En enkel .NET core console applikasjon som viser bysykkelstasjonene i Oslo

Start cmd å gå til mappa der fila Bysykkel.sln er.
Publiser applikasjonen med ønsket runtime for å kunne kjøre programmet (.exe):

	dotnet publish -c Release -r win10-x64
	dotnet publish -c Release -r ubuntu.16.10-x64


For Windows 10 blir programmet publisert i mappa ..\BysykkelConsoleApp\bin\Release\netcoreapp2.1\win10-x64\

API
https://developer.oslobysykkel.no/api

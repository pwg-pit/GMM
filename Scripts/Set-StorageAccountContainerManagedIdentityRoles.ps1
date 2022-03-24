<#
.SYNOPSIS
Adds the app service's managed service identity as a storage blob data contributor on the specified storage account.

.DESCRIPTION
Adds the app service's managed service identity as a storage blob data contributor on the specified storage account so we don't need connection strings as much. 
This should be run by an owner on the subscription after the storage account and app service have been set up.
This should only have to be run once per function app.

.PARAMETER SolutionAbbreviation
The abbreviation for your solution.

.PARAMETER EnvironmentAbbreviation
A 2-6 character abbreviation for your environment.

.PARAMETER FunctionAppName
Function app name

.PARAMETER StorageAccountName
Storage account name

.PARAMETER ErrorActionPreference
Parameter description

.EXAMPLE
Set-StorageAccountContainerManagedIdentityRoles	-SolutionAbbreviation "gmm" `
												-EnvironmentAbbreviation "<env>" `
												-StorageAccountName "<name>" `
												-FunctionAppName "<function app name>" `
												-Verbose
#>
function Set-StorageAccountContainerManagedIdentityRoles 
{
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $True)]
		[string] $SolutionAbbreviation,
		[Parameter(Mandatory = $True)]
		[string] $EnvironmentAbbreviation,
		[Parameter(Mandatory = $True)]
		[string] $StorageAccountName,        
		[Parameter(Mandatory = $True)]
		[string] $FunctionAppName,
		[Parameter(Mandatory = $False)]
		[string] $ErrorActionPreference = $Stop
	)

	Write-Host "Granting app service access to storage account blobs";

	$resourceGroupName = "$SolutionAbbreviation-data-$EnvironmentAbbreviation";
	$appServicePrincipal = Get-AzADServicePrincipal -DisplayName $FunctionAppName;
    
	# Grant the app service access to the storage account blobs
	if (![string]::IsNullOrEmpty($StorageAccountName)) 
	{
		$storageAccountObject = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $StorageAccountName;

		if ($null -eq (Get-AzRoleAssignment -ObjectId $appServicePrincipal.Id -Scope $storageAccountObject.Id)) 
		{
			New-AzRoleAssignment -ObjectId $appServicePrincipal.Id -Scope $storageAccountObject.Id -RoleDefinitionName "Storage Blob Data Contributor";
			Write-Host "Added role assignment to allow $FunctionAppName to access on the $StorageAccountName blobs.";
		}
		else 
		{
			Write-Host "$FunctionAppName already has access to $StorageAccountName blobs.";
		}
	}    
    	
	Write-Host "Done.";
}
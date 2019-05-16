#Read https://docs.microsoft.com/en-us/powershell/module/Microsoft.PowerShell.Utility/Invoke-RestMethod?view=powershell-5.0
#Running this script:  .\post.ps1 -Uri "https://localhost:44342/api/Admin/healthcheck"
param (
	[Parameter(Mandatory=$true)][string]$Uri
)

Invoke-RestMethod -Method Post -Uri ${Uri}

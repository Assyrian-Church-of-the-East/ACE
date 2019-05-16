try
{
	# assumes we run from the repository root
	cd .\src\Database\Isg.Database.Common

    # drop databases
	dotnet ef database drop -c IsgSpdiCommonDbContext -p ..\Isg.Database.Common -s ..\Isg.Database.Common -f -v
    dotnet ef database drop -c IsgCdiSeCommonDbContext -p ..\Isg.Database.Common -s ..\Isg.Database.Common -f -v

	# update databases
	"Update database ISGSPDI.IsgCommon"
	dotnet ef database update -c IsgSpdiCommonDbContext -p ..\Isg.Database.Common -s ..\Isg.Database.Common -v
    "Update database ISCDI_SE.IsgCommon"
	dotnet ef database update -c IsgCdiSeCommonDbContext -p ..\Isg.Database.Common -s ..\Isg.Database.Common -v

	"Update database ISGSPDI.IsgImport"
	dotnet ef database update -c IsgSpdiImportDbContext -p ..\Isg.Database.Import -s ..\Isg.Database.Import -v 
	"Update database ISCDI_SE.IsgImport"
	dotnet ef database update -c IsgCdiSeImportDbContext -p ..\Isg.Database.Import -s ..\Isg.Database.Import -v

	"Update database ISGSPDI.IsgConsolidate"
	dotnet ef database update -c IsgSpdiConsolidateDbContext -p ..\Isg.Database.Consolidate -s ..\Isg.Database.Consolidate -v
	"Update database ISCDI_SE.IsgConsolidate"
	dotnet ef database update -c IsgCdiSeConsolidateDbContext -p ..\Isg.Database.Consolidate -s ..\Isg.Database.Consolidate -v

	"Update database ISGSPDI.IsgPhysicalPackage"
	dotnet ef database update -c IsgSpdiPhysicalPackageDbContext -p ..\Isg.Database.PhysicalPackage -s ..\Isg.Database.PhysicalPackage -v
	"Update database ISCDI_SE.IsgPhysicalPackage"
	dotnet ef database update -c IsgCdiSePhysicalPackageDbContext -p ..\Isg.Database.PhysicalPackage -s ..\Isg.Database.PhysicalPackage -v
	
	"Update database ISGSPDI.IsgLogicalPackage"
	dotnet ef database update -c IsgSpdiLogicalPackageDbContext -p ..\Isg.Database.LogicalPackage -s ..\Isg.Database.LogicalPackage -v
	
	# get us back to the repository root
	cd ..\..\..
}
catch
{
    Write-Error $_.Exception.ToString()
    Read-Host -Prompt "The above error occurred. Press Enter to exit."
}
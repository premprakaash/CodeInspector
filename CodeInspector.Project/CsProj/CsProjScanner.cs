using System.Xml.Linq;

namespace CodeInspector.Project.CsProj;

public class CsProjScanner
{
    public CsProjInfo Scan(string csprojFile)
    {
        if (!File.Exists(csprojFile))
            throw new FileNotFoundException(csprojFile);

        var doc = XDocument.Load(csprojFile);

        var info = new CsProjInfo
        {
            ProjectName = Path.GetFileNameWithoutExtension(csprojFile),
            ProjectPath = csprojFile
        };

        var propertyGroup = doc.Root?
            .Elements("PropertyGroup")
            .FirstOrDefault();

        if (propertyGroup != null)
        {
            info.TargetFramework =
                propertyGroup.Element("TargetFramework")?.Value ?? "";

            info.OutputType =
                propertyGroup.Element("OutputType")?.Value ?? "";

            info.LangVersion =
                propertyGroup.Element("LangVersion")?.Value ?? "";

            info.NullableEnabled =
                propertyGroup.Element("Nullable")?.Value == "enable";

            info.ImplicitUsingsEnabled =
                propertyGroup.Element("ImplicitUsings")?.Value == "enable";
        }

        foreach (var package in doc.Descendants("PackageReference"))
        {
            info.Packages.Add(new PackageReference
            {
                Name = package.Attribute("Include")?.Value ?? "",
                Version = package.Attribute("Version")?.Value ?? ""
            });
        }

        foreach (var project in doc.Descendants("ProjectReference"))
        {
            var include = project.Attribute("Include")?.Value;

            if (!string.IsNullOrWhiteSpace(include))
                info.ProjectReferences.Add(include);
        }

        return info;
    }
}
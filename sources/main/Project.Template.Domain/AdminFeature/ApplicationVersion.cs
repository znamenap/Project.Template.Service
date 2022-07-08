using CSharpFunctionalExtensions;

using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Project.Template.Domain.AdminFeature
{
    /// <summary>
    /// The application version.
    /// </summary>
    public class ApplicationVersion : ValueObject
    {
        /// <summary>
        /// Gets the application title.
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Gets the product name.
        /// </summary>
        public string Product { get; private set; }
        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string Company { get; private set; }
        /// <summary>
        /// Gets the configuration name.
        /// </summary>
        public string Configuration { get; private set; }
        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public string AssemblyVersion { get; private set; }
        /// <summary>
        /// Gets the file version.
        /// </summary>
        public string FileVersion { get; private set; }
        /// <summary>
        /// Gets the informational version.
        /// </summary>
        public string InformationalVersion { get; private set; }
        /// <summary>
        /// Gets the copyright.
        /// </summary>
        public string Copyright { get; private set; }
        /// <summary>
        /// Gets the trademark.
        /// </summary>
        public string Trademark { get; private set; }

        /// <summary>
        /// Returns the string representation.
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(Title))
            {
                sb.Append(Title);
            }
            if (!string.IsNullOrEmpty(Product))
            {
                sb.Append(", ");
                sb.Append(Product);
            }
            if (!string.IsNullOrEmpty(Title))
            {
                sb.Append(", ");
                sb.Append(Title);
            }
            if (!string.IsNullOrEmpty(InformationalVersion))
            {
                sb.Append(", ");
                sb.Append(InformationalVersion);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Gets the equality components.
        /// </summary>
        /// <returns>A list of object.</returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
            yield return Product;
            yield return Description;
            yield return Company;
            yield return Copyright;
            yield return Trademark;
            yield return Configuration;
            yield return AssemblyVersion;
            yield return FileVersion;
            yield return InformationalVersion;
        }

        /// <summary>
        /// Creates the application version value object.
        /// </summary>
        /// <returns>An ApplicationVersion.</returns>
        public static ApplicationVersion Create()
        {
            var assembly = typeof(ApplicationVersion).Assembly;
            return new ApplicationVersion {
                Title = assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title,
                Product = assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product,
                Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description,
                Company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company,
                Copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright,
                Trademark = assembly.GetCustomAttribute<AssemblyTrademarkAttribute>()?.Trademark,
                Configuration = assembly.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration,
                AssemblyVersion = assembly.GetCustomAttribute<AssemblyVersionAttribute>()?.Version,
                FileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version,
                InformationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion,
            };
        }
    }
}

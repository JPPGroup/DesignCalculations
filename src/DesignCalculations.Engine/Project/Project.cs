using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Jpp.DesignCalculations.Engine.Project
{
    public class Project : CalculationContainer
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ProjectReference { get; set; }

        public string Client { get; set; }

        public DateTime LastModified { get; private set; }

        public IProjectStandard Standard { get; set; }

        public Dictionary<Guid, Element> Elements { get; private set; }

        public Project()
        {
            Id = Guid.NewGuid();
            Elements = new Dictionary<Guid, Element>();
        }

        //TODO: Move this somewhere to be cached??
        public static Dictionary<string, IProjectStandard> GetAvailableStandards()
        {
            var type = typeof(IProjectStandard);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract);

            Dictionary<string, IProjectStandard> standards = new Dictionary<string, IProjectStandard>();

            foreach (Type t in types)
            {
                IProjectStandard standard = (IProjectStandard) Activator.CreateInstance(t);
                standards.Add(standard.Name, standard);
            }

            return standards;
        }

        public async Task<Project> DuplicateFromTemplate()
        {
            MemoryStream buffer = new MemoryStream();
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new IProjectStandardConverter());
            await JsonSerializer.SerializeAsync(buffer, this, options);

            buffer.Position = 0;
            Project? newInstance = await JsonSerializer.DeserializeAsync<Project>(buffer, options);
            if(newInstance == null)
              throw new NullReferenceException("Deserialized clone is null");

            newInstance.Name = String.Empty;

            return newInstance;
        }
    }
}

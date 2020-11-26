using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jpp.DesignCalculations.Engine.Project;

namespace Nautilus.Client.Data
{
    public interface ITemplateSource
    {
        string Name { get; }

        IEnumerable<Project> GetProjects();

        Task AddProjectAsync(Project p);

        Task<Project?> GetProjectAsync(Guid id);

        Task<bool> DeleteProjectAsync(Guid id);

        event EventHandler ProjectsChanged;  
    }
}
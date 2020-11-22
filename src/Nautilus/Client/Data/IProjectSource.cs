using System.Collections.Generic;
using System.Threading.Tasks;
using Jpp.DesignCalculations.Engine;

namespace Nautilus.Client.Data
{
    public interface IProjectSource
    {
        string Name { get; }

        IEnumerable<Project> GetProjects();

        Task AddProjectAsync(Project p);

    }
}
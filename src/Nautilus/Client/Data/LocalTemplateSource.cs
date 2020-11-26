using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Jpp.DesignCalculations.Engine.Project;

namespace Nautilus.Client.Data
{
    class LocalTemplateSource : ITemplateSource
    {
        private ISyncLocalStorageService _localStorage;
        private ILocalStorageService _asyncLocalStorage;
        private List<Project> _projects;

        public LocalTemplateSource(ISyncLocalStorageService localStorage, ILocalStorageService asyncLocalStorage)
        {
            /*_localStorage = localStorage;
            _asyncLocalStorage = asyncLocalStorage;
            _projects = _localStorage.GetItem<List<Project>>("projects");
            if(_projects == null)
                _projects = new List<Project>();*/
            _projects = new List<Project>()
            {
                new Project()
                {
                    Name = "Blank Template"
                }
            };
        }

        public string Name { get; } = "Browser";

        public IEnumerable<Project> GetProjects()
        {
            return _projects;
        }

        public async Task AddProjectAsync(Project p)
        {
            _projects.Add(p);
            await SaveAsync();
        }

        public async Task<Project?> GetProjectAsync(Guid id)
        {
            //TODO: Parallelise? Async?
            return _projects.First(p => p.Id.Equals(id));
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            int removed = _projects.RemoveAll(p => p.Id == id);
            bool found = removed > 0;
            if(found)
                await SaveAsync();
            return found;
        }

        public event EventHandler ProjectsChanged;

        private async Task SaveAsync()
        {
            /*await _asyncLocalStorage.SetItemAsync("projects", _projects);
            ProjectsChanged?.Invoke(this, EventArgs.Empty);*/
        }
    }
}

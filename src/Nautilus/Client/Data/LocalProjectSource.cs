using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Jpp.DesignCalculations.Engine;

namespace Nautilus.Client.Data
{
    class LocalProjectSource : IProjectSource
    {
        private ISyncLocalStorageService _localStorage;
        private ILocalStorageService _asyncLocalStorage;
        private List<Project> _projects;

        public LocalProjectSource(ISyncLocalStorageService localStorage, ILocalStorageService asyncLocalStorage)
        {
            _localStorage = localStorage;
            _asyncLocalStorage = asyncLocalStorage;
            _projects = _localStorage.GetItem<List<Project>>("projects");
            if(_projects == null)
                _projects = new List<Project>();
        }

        public string Name { get; } = "Browser";

        public IEnumerable<Project> GetProjects()
        {
            return _projects;
        }

        public async Task AddProjectAsync(Project p)
        {
            _projects.Add(p);
            SaveAsync();
        }

        private async void SaveAsync()
        {
            await _asyncLocalStorage.SetItemAsync("projects", _projects);
        }
    }
}

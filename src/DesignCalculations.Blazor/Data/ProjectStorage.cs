using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Jpp.DesignCalculations.Engine.Project;
using Newtonsoft.Json;

namespace DesignCalculations.Blazor.Data
{
    public class ProjectStorage
    {
        //TODO: This is temp, add proper backing support
        private Dictionary<Guid, Project> Storage;

        private ILocalStorageService _browserStorage;

        public bool Initialized { get; private set; }

        public ProjectStorage(ILocalStorageService browserStorage)
        {
            Storage = new Dictionary<Guid, Project>();
            _browserStorage = browserStorage;
            Initialized = false;
        }

        public async Task Initialize()
        {
            string json = await _browserStorage.GetItemAsStringAsync("DC_Browser_Storage");
            if (!String.IsNullOrWhiteSpace(json))
                Storage = JsonConvert.DeserializeObject<Dictionary<Guid, Project>>(json);
            if(Storage == null)
                Storage = new Dictionary<Guid, Project>();
            
            Initialized = true;
        }

        public async Task Flush()
        {
            
            await _browserStorage.SetItemAsync("DC_Browser_Storage", JsonConvert.SerializeObject(Storage));
            
        }

        public IEnumerable<Project> AllProjects()
        {
            return Storage.Values;
        }

        public Project GetProject(Guid id)
        {
            if (Storage.ContainsKey(id))
                return Storage[id];

            return null;
        }

        public async Task NewProject(Project p)
        {
            Storage.Add(p.Id, p);
            await Flush();
        }

        public string ExportProject(Guid id)
        {
            return JsonConvert.SerializeObject(GetProject(id));
        }

        public void ImportProject(string projectJson)
        {
            Project p = JsonConvert.DeserializeObject<Project>(projectJson);
            NewProject(p);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    public class ProjectList
    {
        private List<ProjectDataJSON> _dataJSON;
        public List<ProjectDataJSON> DataJson => _dataJSON;

        public ProjectList()
        {
            _dataJSON = new List<ProjectDataJSON>();
        }

        public ProjectList(ProjectListJSON json)
        {
            _dataJSON = json.DataJson;
        }

        public void Add(ProjectDataJSON dataJSON)
        {
            _dataJSON.Add(dataJSON);
        }

        public ProjectListJSON getSaveable()
        {
            return new ProjectListJSON()
            {
                DataJson = _dataJSON,
            };
        }
    }
}
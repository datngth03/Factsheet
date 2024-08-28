using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sabeco_Factsheet.Blazor.Client.Components.Toolbar
{
    public class ShowActionListView : IScopedDependency
    {
        private bool unreadCount;

        public bool UnreadCount
        {
            get => unreadCount;
            set
            {
                unreadCount = value;
                UnreadCountChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler UnreadCountChanged;
    }
}

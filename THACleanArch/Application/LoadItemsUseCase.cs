using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THACleanArch.Domain;

namespace THACleanArch.Application
{
    public interface IItemsRepository
    {
        List<Item> LoadItems();
    }
    public class LoadItemsUseCase  
    {
        private IItemsRepository _itemsRepos;

        public LoadItemsUseCase(IItemsRepository itemsRepos)
        {
            _itemsRepos = itemsRepos;
        }

        public List<Item> Execute()
        {
            return _itemsRepos.LoadItems();
        }
    }
}


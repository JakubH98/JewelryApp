using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THACleanArch.Application;
using THACleanArch.Domain;
using THACleanArch.InterfaceAdapter;
using static THACleanArch.Domain.ItemDecorator;

namespace THACleanArch.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileReader fileReader = new FileReaderAdapter();
            IItemsRepository itemsRepos = new FileItemRepos(fileReader);
            LoadItemsUseCase loadItemsUseCase = new LoadItemsUseCase(itemsRepos);

            var items = loadItemsUseCase.Execute();

            Console.WriteLine("Available Items:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}: {item.Description} - {item.Price} kr");
            }

            Console.WriteLine("Select an Item by Id:");
            string selectedItemId = Console.ReadLine();
            var selectedItem = items.FirstOrDefault(item => item.Id == selectedItemId);
            if(selectedItem == null)
            {
                Console.WriteLine("Nothing selected");
            }
            Console.WriteLine($"You have selected:{selectedItem.Description}");
            Console.WriteLine("Add Gift Wrapping? (yes/no)");
            string giftWrapping = Console.ReadLine();
            if (giftWrapping.ToLower() == "yes")
            {
                selectedItem = new GiftWrapping(selectedItem);
            }

            Console.WriteLine("Add Shipment? (yes/no)");
            string shipment = Console.ReadLine();
            if (shipment.ToLower() == "yes")
            {
                selectedItem = new Shipment(selectedItem);
            }

            Console.WriteLine($"Total Price: {selectedItem.Price} kr");

            Console.Read();


        }
    }
}


using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class Program
{
    public static void Main()
    {
        ObservableCollection<string> collection = new ObservableCollection<string>();

        collection.CollectionChanged += CollectionChangedHandler;

        collection.Add("venn");
        collection.Add("rann");
        collection.Remove("xett");
    }

    private static void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                Console.WriteLine($"Element '{e.NewItems[0]}' is added in collection");
                break;

            case NotifyCollectionChangedAction.Remove:
                Console.WriteLine($"Element '{e.OldItems[0]}' is removed from collection");
                break;
        }
    }
}

